using CommonCode;
using System.Linq;
using System.Text;

namespace ReportGenerator5
{
    [IsPure]
    public sealed class CityReportGenerator
    {
        private readonly CustomerReportGenerator customerReportGenerator;

        public CityReportGenerator(CustomerReportGenerator customerReportGenerator)
        {
            this.customerReportGenerator = customerReportGenerator;
        }

        public CityReport Generate(City city)
        {
            var sb = new MyStringBuilder();

            sb.AppendLine("City name: " + city.Name);

            sb.AppendLine("Number of customers in the city: " + city.Customers.Length.AsString());
            sb.AppendLine();

            foreach (var subReport in city.Customers.Select(x => customerReportGenerator.Generate(x)))
            {
                sb.AppendLine(subReport.Value);
            }

            return new CityReport(sb.ToString());
        }
    }
}