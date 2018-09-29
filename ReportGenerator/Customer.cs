using System.Collections.Immutable;

namespace ReportGenerator
{
    public sealed class Customer
    {
        public Customer(string name, ImmutableArray<Order> orders)
        {
            Name = name;
            Orders = orders;
        }

        public string Name { get; }

        public ImmutableArray<Order> Orders { get; }
    }
}