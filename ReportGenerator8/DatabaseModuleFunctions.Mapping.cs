using System;


namespace ReportGenerator8
{
    public static class DatabaseModule
    {
        public static Func<Unit, System.Collections.Immutable.ImmutableArray<City>> LoadAllDataWithoutOrders()
        {
            return new LoadAllDataWithoutOrdersToFunctionClass().Invoke;
        }

        public static Func<Customer, System.Collections.Immutable.ImmutableArray<Order>> LoadOrdersForCustomer()
        {
            return new LoadOrdersForCustomerToFunctionClass().Invoke;
        }

        private class LoadAllDataWithoutOrdersToFunctionClass
        {
            public System.Collections.Immutable.ImmutableArray<City> Invoke(Unit input)
            {
                return DatabaseModuleFunctions.LoadAllDataWithoutOrders();
            }
        }

        private class LoadOrdersForCustomerToFunctionClass
        {
            public System.Collections.Immutable.ImmutableArray<Order> Invoke(Customer input)
            {
                return DatabaseModuleFunctions.LoadOrdersForCustomer(input);
            }
        }
    }
}