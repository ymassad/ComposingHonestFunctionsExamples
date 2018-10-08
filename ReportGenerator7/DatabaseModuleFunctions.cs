using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCode;

namespace ReportGenerator7
{
    public static class DatabaseModuleFunctions
    {
        private static int DummyState;

        public static ImmutableArray<City> LoadAllDataWithoutOrders()
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

        public static ImmutableArray<Order> LoadOrdersForCustomer(Customer customer)
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

    }
}
