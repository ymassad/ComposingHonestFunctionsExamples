using System;
using System.Collections.Immutable;
using CommonCode.Functions;

namespace ReportGenerator8
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderReportFormattingSettings =
                new OrderReportFormattingSettings(args.Length > 0 && args[0].Equals("noNumberOfLines"));

            var cities = DatabaseModuleFunctions.LoadAllDataWithoutOrders();

            var generateReportForOrder =
                ReportingModule.GenerateReportForOrder();

            var generateReportForCustomer =
                ReportingModule.GenerateReportForCustomer()
                    .HonestlyInject(
                        generateReportForOrder);

            var generateReportForCity =
                ReportingModule.GenerateReportForCity()
                    .HonestlyInject(generateReportForCustomer);

            var generateReportHonest =
                ReportingModule.GenerateReport()
                    .HonestlyInject(generateReportForCity);

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
