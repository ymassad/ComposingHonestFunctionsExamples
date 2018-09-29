using System.Collections.Immutable;
using System.Linq;
using System.Text;
using CommonCode;

namespace ReportGenerator5
{
    [IsPure]
    public sealed class ReportGenerator
    {
        private readonly CityReportGenerator cityReportGenerator;

        public ReportGenerator(CityReportGenerator cityReportGenerator)
        {
            this.cityReportGenerator = cityReportGenerator;
        }

        public Report Generate(
            ImmutableArray<City> cities)
        {
            var sb = new MyStringBuilder();

            sb.AppendLine("Number of cities: " + cities.Length.AsString());

            foreach (var subReport in cities.Select(x => cityReportGenerator.Generate(x)))
            {
                sb.AppendLine(subReport.Value);
            }

            return new Report(sb.ToString());
        }

    }
}