using CommonCode;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace ReportGenerator6
{
    [IsPure]
    public sealed class ReportGenerator : IReportGenerator
    {
        private readonly ICityReportGenerator cityReportGenerator;

        public ReportGenerator(ICityReportGenerator cityReportGenerator)
        {
            this.cityReportGenerator = cityReportGenerator;
        }

        public Report Generate(
            ImmutableArray<City> cities)
        {
            var sb = new MyStringBuilder();

            sb.AppendLine("Number of cities: " + cities.Length.AsString());
            sb.AppendLine();

            foreach (var subReport in cities.Select(x => cityReportGenerator.Generate(x)))
            {
                sb.AppendLine(subReport.Value);
            }

            return new Report(sb.ToString());
        }

    }
}