using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using CommonCode;

namespace ReportGenerator6
{
    [IsPure]
    public sealed class CustomerReportGenerator : ICustomerReportGenerator
    {
        private readonly IOrderReportGenerator orderReportGenerator;
        private readonly Func<Customer, ImmutableArray<Order>> getOrdersForCustomer;
        public CustomerReportGenerator(
            IOrderReportGenerator orderReportGenerator,
            Func<Customer, ImmutableArray<Order>> getOrdersForCustomer)
        {
            this.orderReportGenerator = orderReportGenerator;
            this.getOrdersForCustomer = getOrdersForCustomer;
        }

        public CustomerReport Generate(Customer customer)
        {
            var sb = new MyStringBuilder();

            sb.AppendLine("Customer name: " + customer.Name);

            var orders = getOrdersForCustomer(customer);

            sb.AppendLine("Number of orders for customer: " + orders.Length.AsString());

            foreach (var subReport in orders.Select(order => orderReportGenerator.Generate(order)))
            {
                sb.AppendLine(subReport.Value);
            }

            return new CustomerReport(sb.ToString());
        }

    }
}