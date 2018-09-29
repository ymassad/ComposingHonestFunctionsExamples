using CommonCode;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace ReportGenerator
{
    class Program
    {
        private static int DummySate;

        static void Main(string[] args)
        {
            var cities = LoadAllData();

            var report = GenerateReport(cities);

            SaveReport(report);
        }
        
        [IsPure]
        private static Report GenerateReport(ImmutableArray<City> cities)
        {
            var sb = new MyStringBuilder();
            
            sb.AppendLine("Number of cities: " + cities.Length.AsString());

            foreach (var subReport in cities.Select(GenerateReportForCity))
            {
                sb.AppendLine(subReport.Value);
            }

            return new Report(sb.ToString());
        }

        [IsPure]
        private static CityReport GenerateReportForCity(City city)
        {
            var sb = new MyStringBuilder();

            sb.AppendLine("City name: " + city.Name);

            sb.AppendLine("Number of customers in the city: " + city.Customers.Length.AsString());

            foreach (var subReport in city.Customers.Select(GenerateReportForCustomer))
            {
                sb.AppendLine(subReport.Value);
            }

            return new CityReport(sb.ToString());
        }

        [IsPure]
        private static CustomerReport GenerateReportForCustomer(Customer customer)
        {
            var sb = new MyStringBuilder();

            sb.AppendLine("Customer name: " + customer.Name);

            sb.AppendLine("Number of orders for customer: " + customer.Orders.Length.AsString());

            foreach (var subReport in customer.Orders.Select(GenerateReportForOrder))
            {
                sb.AppendLine(subReport.Value);
            }

            return new CustomerReport(sb.ToString());
        }

        [IsPure]
        private static OrderReport GenerateReportForOrder(Order order)
        {
            var sb = new MyStringBuilder();

            sb.AppendLine("Order date: " + FormatDate(order.OrderDate));

            sb.AppendLine("Number of order lines: " + order.OrderLines.Length.AsString());

            decimal total = 0m;

            foreach (var orderLine in order.OrderLines)
            {
                var lineTotal = orderLine.ItemCount * orderLine.ItemPrice;

                total += lineTotal;

                sb.AppendLine(orderLine.ProductName + ": " + orderLine.ItemCount.AsString() + " * " + orderLine.ItemPrice.AsString() + "$ = " + lineTotal.AsString() + "$");
            }

            sb.AppendLine("Total: " + total.AsString() + "$");
            return new OrderReport(sb.ToString());
        }

        [IsPure]
        private static string FormatDate(DateTime date)
        {
            return date.Day.AsString() + "-" + date.Month.AsString() + "-" + date.Year.AsString();
        }

        private static ImmutableArray<City> LoadAllData()
        {
            DummySate++;

            return ImmutableArray.Create(
                    new City(
                        "New York",
                        ImmutableArray.Create(
                            new Customer(
                                "Adam Smith",
                                ImmutableArray.Create(
                                    new Order(
                                        new DateTime(2018, 9, 22),
                                        ImmutableArray.Create(
                                            new OrderLine("Car", 2, 100m))))),
                            new Customer(
                                "John Smith",
                                ImmutableArray.Create(
                                    new Order(
                                        new DateTime(2018, 9, 21),
                                        ImmutableArray.Create(
                                            new OrderLine("Bus", 3, 200m))))))),
                    new City(
                        "Paris",
                        ImmutableArray.Create(
                            new Customer(
                                "Mary Smith",
                                ImmutableArray.Create(
                                    new Order(
                                        new DateTime(2018, 9, 20),
                                        ImmutableArray.Create(
                                            new OrderLine("Plane", 4, 500m))))))));       
        }

        private static void SaveReport(Report report)
        {
            Console.Write(report.Value);
        }
    }
}
