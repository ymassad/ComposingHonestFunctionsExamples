using System.Collections.Immutable;

namespace ReportGenerator2
{
    public sealed class Customer
    {
        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}