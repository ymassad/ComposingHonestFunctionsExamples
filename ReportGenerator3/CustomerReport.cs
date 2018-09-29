namespace ReportGenerator3
{
    public sealed class CustomerReport
    {
        public CustomerReport(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}