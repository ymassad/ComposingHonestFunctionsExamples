using System;
using System.Collections.Immutable;
using System.Linq;
using CommonCode;

namespace ReportGenerator9
{
    public static class ReportingModuleFunctions
    {
        [IsPure]
        public static Report GenerateReport(
            Func<City, CityReport> generateCityReport,
            ImmutableArray<City> cities)
        {
            var sb = new MyStringBuilder();

            sb.AppendLine("Number of cities: " + cities.Length.AsString());
            sb.AppendLine();

            foreach (var subReport in cities.Select(x => generateCityReport(x)))
            {
                sb.AppendLine(subReport.Value);
            }

            return new Report(sb.ToString());
        }

        [IsPure]
        public static CityReport GenerateReportForCity(
            Func<Customer, CustomerReport> generateCustomerReport,
            City city)
        {
            var sb = new MyStringBuilder();

            sb.AppendLine("City name: " + city.Name);

            sb.AppendLine("Number of customers in the city: " + city.Customers.Length.AsString());
            sb.AppendLine();

            foreach (var subReport in city.Customers.Select(x => generateCustomerReport(x)))
            {
                sb.AppendLine(subReport.Value);
            }

            return new CityReport(sb.ToString());
        }

        [IsPure]
        public static CustomerReport GenerateReportForCustomer(
            Func<Customer, ImmutableArray<Order>> getOrdersForCustomer,
            Func<Order, OrderReport> generateOrderReport,
            Customer customer)
        {
            var sb = new MyStringBuilder();

            sb.AppendLine("Customer name: " + customer.Name);

            var orders = getOrdersForCustomer(customer);

            sb.AppendLine("Number of orders for customer: " + orders.Length.AsString());

            foreach (var subReport in orders.Select(order => generateOrderReport(order)))
            {
                sb.AppendLine(subReport.Value);
            }

            return new CustomerReport(sb.ToString());
        }

        [IsPure]
        public static OrderReport GenerateReportForOrder(
            OrderReportFormattingSettings orderReportFormattingSettings,
            Order order)
        {
            var sb = new MyStringBuilder();

            sb.AppendLine("Order date: " + FormatDate(order.OrderDate));

            if (!orderReportFormattingSettings.DontIncludeNumberOrOrderLines)
            {
                sb.AppendLine("Number of order lines: " + order.OrderLines.Length.AsString());
            }

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

    }
}
