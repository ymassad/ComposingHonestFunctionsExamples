using CommonCode;
using System;
using System.Text;

namespace ReportGenerator6
{
    [IsPure]
    public sealed class OrderReportGenerator : IOrderReportGenerator
    {
        private readonly OrderReportFormattingSettings orderReportFormattingSettings;

        public OrderReportGenerator(OrderReportFormattingSettings orderReportFormattingSettings)
        {
            this.orderReportFormattingSettings = orderReportFormattingSettings;
        }

        public OrderReport Generate(Order order)
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

        private static string FormatDate(DateTime date)
        {
            return date.Day.AsString() + "-" + date.Month.AsString() + "-" + date.Year.AsString();
        }

    }
}