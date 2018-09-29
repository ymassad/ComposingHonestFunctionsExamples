using System;
using System.Collections.Immutable;
using CommonCode;
using CommonCode.Functions;


namespace ReportGenerator7
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderReportFormattingSettings =
                new OrderReportFormattingSettings(args.Length > 0 && args[0].Equals("noNumberOfLines"));

            var cities = DatabaseModuleFunctions.LoadAllDataWithoutOrders();

            var generateReportForOrder =
                ReportingModule.GenerateReportForOrder()
                    .PartiallyInvoke(orderReportFormattingSettings);

            var generateReportForCustomer =
                ReportingModule.GenerateReportForCustomer()
                    .PartiallyInvoke(
                        generateReportForOrder,
                        DatabaseModule.LoadOrdersForCustomer());

            var generateReportForCity =
                ReportingModule.GenerateReportForCity()
                    .PartiallyInvoke(generateReportForCustomer);

            var generateReport =
                ReportingModule.GenerateReport()
                    .PartiallyInvoke(generateReportForCity);

            var report = generateReport(cities);

            SaveReport(report);
        }

        private static void SaveReport(Report report)
        {
            Console.Write(report.Value);
        }
    }
}
