namespace TestTask_Products
{
    class PerUnitPriceCalculationHandler : PriceTypeCalculationHandler
    {
        public PerUnitPriceCalculationHandler() : base()
        { }

        public PerUnitPriceCalculationHandler(PriceTypeCalculationHandler next) : base(next)
        {
        }

        protected override void Calculate(Item item)
        {
            if (item.PerUnitPrice != null)
            {
                var itemsCount = item.RemainingCount;
                item.TotalPrice += itemsCount * item.PerUnitPrice.Value;
                item.RemainingCount = 0;
            }
        }
    }
}
