namespace TestTask_Products.PriceCalculations
{
    public class Item
    {
        //ToDo: int -> TKey
        public int ProductId { get; set; }
        public PerUnitPrice PerUnitPrice { get; set; }
        public PerGroupPrice PerGroupPrice { get; set; }
        public int Count { get; set; }
    }
}
