using System.Collections.Immutable;

namespace ReportGenerator6
{
    public interface IReportGenerator
    {
        Report Generate(ImmutableArray<City> cities);
    }
}