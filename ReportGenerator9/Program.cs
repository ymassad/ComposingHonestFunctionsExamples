using System;
using System.Collections.Immutable;
using CommonCode;
using CommonCode.Functions;

namespace ReportGenerator9
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderReportFormattingSettings =
                new OrderReportFormattingSettings(args.Length > 0 && args[0].Equals("noNumberOfLines"));

            var cities = DatabaseModuleFunctions.LoadAllDataWithoutOrders();

            var PureCompose = PureLambda.Create(() =>
            {
                var generateReportForCustomer =
                    ReportingModule.GenerateReportForCustomer()
                        .HonestlyInject(
                            ReportingModule.GenerateReportForOrder());

                var generateReportForCity =
                    ReportingModule.GenerateReportForCity()
                        .HonestlyInject(generateReportForCustomer);

                return ReportingModule.GenerateReport()
                    .HonestlyInject(generateReportForCity);
            });

            var generateReportHonest = PureCompose();

            var generateReport =
                generateReportHonest
                    .PartiallyInvoke(
                        orderReportFormattingSettings,
                        DatabaseModule.LoadOrdersForCustomer());

            var report = generateReport(cities);

            SaveReport(report);
        }

        private static void SaveReport(Report report)
        {
            Console.Write(report.Value);
        }
    }
}
