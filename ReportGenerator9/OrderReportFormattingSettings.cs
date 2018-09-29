namespace ReportGenerator9
{
    public sealed class OrderReportFormattingSettings
    {
        public OrderReportFormattingSettings(bool dontIncludeNumberOrOrderLines)
        {
            DontIncludeNumberOrOrderLines = dontIncludeNumberOrOrderLines;
        }

        public bool DontIncludeNumberOrOrderLines { get; }
    }
}