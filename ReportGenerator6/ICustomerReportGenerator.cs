namespace ReportGenerator6
{
    public interface ICustomerReportGenerator
    {
        CustomerReport Generate(Customer customer);
    }
}