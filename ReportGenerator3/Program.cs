using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using CommonCode;

namespace ReportGenerator3
{
    class Program
    {
        private static int DummySate;

        static void Main(string[] args)
        {
            var cities = LoadAllDataWithoutOrders();

            var report = GenerateReport(cities, LoadOrdersForCustomer);

            SaveReport(report);
        }

        [IsPure]
        private static Report GenerateReport(ImmutableArray<City> cities, Func<Customer, ImmutableArray<Order>> getOrdersForCustomer)
        {
            var sb = new MyStringBuilder();

            sb.AppendLine("Number of cities: " + cities.Length.AsString());
            sb.AppendLine();

            foreach (var subReport in cities.Select(x => GenerateReportForCity(x, getOrdersForCustomer)))
            {
                sb.AppendLine(subReport.Value);
            }

            return new Report(sb.ToString());
        }

        [IsPure]
        private static CityReport GenerateReportForCity(City city, Func<Customer, ImmutableArray<Order>> getOrdersForCustomer)
        {
            var sb = new MyStringBuilder();

            sb.AppendLine("City name: " + city.Name);

            sb.AppendLine("Number of customers in the city: " + city.Customers.Length.AsString());
            sb.AppendLine();

            foreach (var subReport in city.Customers.Select(x => GenerateReportForCustomer(x, getOrdersForCustomer)))
            {
                sb.AppendLine(subReport.Value);
            }

            return new CityReport(sb.ToString());
        }

        [IsPure]
        private static CustomerReport GenerateReportForCustomer(Customer customer, Func<Customer, ImmutableArray<Order>> getOrdersForCustomer)
        {
            var sb = new MyStringBuilder();

            sb.AppendLine("Customer name: " + customer.Name);

            var orders = getOrdersForCustomer(customer);

            sb.AppendLine("Number of orders for customer: " + orders.Length.AsString());

            foreach (var subReport in orders.Select(GenerateReportForOrder))
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

        private static ImmutableArray<City> LoadAllDataWithoutOrders()
        {
            DummySate++;

            return ImmutableArray.Create(
                new City(
                    "New York",
                    ImmutableArray.Create(
                        new Customer("Adam Smith"),
                        new Customer("John Smith"))),
                new City(
                    "Paris",
                    ImmutableArray.Create(
                        new Customer("Mary Smith"))));
        }

        private static ImmutableArray<Order> LoadOrdersForCustomer(Customer customer)
        {
            DummySate++;

            if (customer.Name == "Adam Smith")
            {
                return ImmutableArray.Create(
                    new Order(
                        new DateTime(2018, 9, 22),
                        ImmutableArray.Create(
                            new OrderLine("Car", 2, 100m))));
            }

            if (customer.Name == "John Smith")
            {
                return ImmutableArray.Create(
                    new Order(
                        new DateTime(2018, 9, 21),
                        ImmutableArray.Create(
                            new OrderLine("Bus", 3, 200m))));
            }

            if (customer.Name == "Mary Smith")
            {
                return ImmutableArray.Create(
                    new Order(
                        new DateTime(2018, 9, 20),
                        ImmutableArray.Create(
                            new OrderLine("Plane", 4, 500m))));
            }

            throw new Exception("Unknown customer");
        }

        private static void SaveReport(Report report)
        {
            Console.Write(report.Value);
        }
    }
}
