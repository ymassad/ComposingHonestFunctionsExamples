using System.Linq;
using System.Text;
using CommonCode;

namespace ReportGenerator6
{
    [IsPure]
    public sealed class CityReportGenerator : ICityReportGenerator
    {
        private readonly ICustomerReportGenerator customerReportGenerator;

        public CityReportGenerator(ICustomerReportGenerator customerReportGenerator)
        {
            this.customerReportGenerator = customerReportGenerator;
        }

        public CityReport Generate(City city)
        {
            var sb = new MyStringBuilder();

            sb.AppendLine("City name: " + city.Name);

            sb.AppendLine("Number of customers in the city: " + city.Customers.Length.AsString());

            foreach (var subReport in city.Customers.Select(x => customerReportGenerator.Generate(x)))
            {
                sb.AppendLine(subReport.Value);
            }

            return new CityReport(sb.ToString());
        }
    }
}