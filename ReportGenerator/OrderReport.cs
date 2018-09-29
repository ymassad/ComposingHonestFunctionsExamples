namespace ReportGenerator
{
    public sealed class OrderReport
    {
        public OrderReport(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}