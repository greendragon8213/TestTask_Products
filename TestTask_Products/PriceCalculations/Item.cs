namespace TestTask_Products
{
    public class Item
    {
        //ToDo: int -> TKey
        public int ProductId { get; set; }
        public PerUnitPrice PerUnitPrice { get; set; }
        public PerGroupPrice PerGroupPrice { get; set; }
        public int RemainingCount { get; set; }

        //ToDo: or calculated price?
        public decimal TotalPrice { get; set; } = 0.0m;
    }
}
