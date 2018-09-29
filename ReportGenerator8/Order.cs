using System;
using System.Collections.Immutable;

namespace ReportGenerator8
{
    public sealed class Order
    {
        public Order(DateTime orderDate, ImmutableArray<OrderLine> orderLines)
        {
            OrderDate = orderDate;
            OrderLines = orderLines;
        }

        public DateTime OrderDate { get; }

        public ImmutableArray<OrderLine> OrderLines { get; }
    }
}