using System;
using System.Collections.Immutable;

namespace ReportGenerator6
{
    class Program
    {
        private static int DummyState;

        static void Main(string[] args)
        {
            var orderReportFormattingSettings =
                new OrderReportFormattingSettings(args.Length > 0 && args[0].Equals("noNumberOfLines"));

            var cities = LoadAllDataWithoutOrders();

            var orderReportGenerator =
                new OrderReportGenerator(
                    orderReportFormattingSettings);

            var customerReportGenerator =
                new CustomerReportGenerator(
                    orderReportGenerator,
                    LoadOrdersForCustomer);

            var cityReportGenerator =
                new CityReportGenerator(
                    customerReportGenerator);

            var reportGenerator =
                new ReportGenerator(
                    cityReportGenerator);

            var report = reportGenerator.Generate(cities);

            SaveReport(report);
        }

        private static ImmutableArray<City> LoadAllDataWithoutOrders()
        {
            DummyState++;

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
            DummyState++;

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
