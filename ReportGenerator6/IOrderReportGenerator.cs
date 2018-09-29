namespace ReportGenerator6
{
    public interface IOrderReportGenerator
    {
        OrderReport Generate(Order order);
    }
}