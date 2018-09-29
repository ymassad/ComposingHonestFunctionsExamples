using System;


namespace ReportGenerator7
{
    public static class ReportingModule
    {
        public static Func<(Func<City, CityReport> generateCityReport, System.Collections.Immutable.ImmutableArray<City> cities), Report> GenerateReport()
        {
            return new GenerateReportToFunctionClass().Invoke;
        }

        public static Func<System.Collections.Immutable.ImmutableArray<City>, Report> GenerateReport(Func<City, CityReport> generateCityReport)
        {
            return new GenerateReportToFunctionClass(generateCityReport).Invoke;
        }

        public static Func<(Func<Customer, CustomerReport> generateCustomerReport, City city), CityReport> GenerateReportForCity()
        {
            return new GenerateReportForCityToFunctionClass().Invoke;
        }

        public static Func<City, CityReport> GenerateReportForCity(Func<Customer, CustomerReport> generateCustomerReport)
        {
            return new GenerateReportForCityToFunctionClass(generateCustomerReport).Invoke;
        }

        public static Func<(Func<Customer, System.Collections.Immutable.ImmutableArray<Order>> getOrdersForCustomer, Func<Order, OrderReport> generateOrderReport, Customer customer), CustomerReport> GenerateReportForCustomer()
        {
            return new GenerateReportForCustomerToFunctionClass().Invoke;
        }

        public static Func<Customer, CustomerReport> GenerateReportForCustomer(Func<Customer, System.Collections.Immutable.ImmutableArray<Order>> getOrdersForCustomer, Func<Order, OrderReport> generateOrderReport)
        {
            return new GenerateReportForCustomerToFunctionClass(getOrdersForCustomer, generateOrderReport).Invoke;
        }

        public static Func<(OrderReportFormattingSettings orderReportFormattingSettings, Order order), OrderReport> GenerateReportForOrder()
        {
            return new GenerateReportForOrderToFunctionClass().Invoke;
        }

        private class GenerateReportToFunctionClass
        {
            private readonly Func<City, CityReport> generateCityReport;
            public GenerateReportToFunctionClass()
            {
            }

            public GenerateReportToFunctionClass(Func<City, CityReport> generateCityReport)
            {
                this.generateCityReport = generateCityReport;
            }

            public Report Invoke((Func<City, CityReport> generateCityReport, System.Collections.Immutable.ImmutableArray<City> cities)input)
            {
                return ReportingModuleFunctions.GenerateReport(input.generateCityReport, input.cities);
            }

            public Report Invoke(System.Collections.Immutable.ImmutableArray<City> input)
            {
                return ReportingModuleFunctions.GenerateReport(generateCityReport, input);
            }
        }

        private class GenerateReportForCityToFunctionClass
        {
            private readonly Func<Customer, CustomerReport> generateCustomerReport;
            public GenerateReportForCityToFunctionClass()
            {
            }

            public GenerateReportForCityToFunctionClass(Func<Customer, CustomerReport> generateCustomerReport)
            {
                this.generateCustomerReport = generateCustomerReport;
            }

            public CityReport Invoke((Func<Customer, CustomerReport> generateCustomerReport, City city)input)
            {
                return ReportingModuleFunctions.GenerateReportForCity(input.generateCustomerReport, input.city);
            }

            public CityReport Invoke(City input)
            {
                return ReportingModuleFunctions.GenerateReportForCity(generateCustomerReport, input);
            }
        }

        private class GenerateReportForCustomerToFunctionClass
        {
            private readonly Func<Customer, System.Collections.Immutable.ImmutableArray<Order>> getOrdersForCustomer;
            private readonly Func<Order, OrderReport> generateOrderReport;
            public GenerateReportForCustomerToFunctionClass()
            {
            }

            public GenerateReportForCustomerToFunctionClass(Func<Customer, System.Collections.Immutable.ImmutableArray<Order>> getOrdersForCustomer, Func<Order, OrderReport> generateOrderReport)
            {
                this.getOrdersForCustomer = getOrdersForCustomer;
                this.generateOrderReport = generateOrderReport;
            }

            public CustomerReport Invoke((Func<Customer, System.Collections.Immutable.ImmutableArray<Order>> getOrdersForCustomer, Func<Order, OrderReport> generateOrderReport, Customer customer)input)
            {
                return ReportingModuleFunctions.GenerateReportForCustomer(input.getOrdersForCustomer, input.generateOrderReport, input.customer);
            }

            public CustomerReport Invoke(Customer input)
            {
                return ReportingModuleFunctions.GenerateReportForCustomer(getOrdersForCustomer, generateOrderReport, input);
            }
        }

        private class GenerateReportForOrderToFunctionClass
        {
            public OrderReport Invoke((OrderReportFormattingSettings orderReportFormattingSettings, Order order)input)
            {
                return ReportingModuleFunctions.GenerateReportForOrder(input.orderReportFormattingSettings, input.order);
            }
        }
    }
}