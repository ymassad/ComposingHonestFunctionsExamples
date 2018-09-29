namespace ReportGenerator
{
    public sealed class OrderLine
    {
        public OrderLine(string productName, int itemCount, decimal itemPrice)
        {
            ProductName = productName;
            ItemCount = itemCount;
            ItemPrice = itemPrice;
        }

        public string ProductName { get; }

        public int ItemCount { get; }

        public decimal ItemPrice { get; }
    }
}