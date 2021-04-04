namespace TestTask_Products.PriceCalculations
{
    class PerUnitPriceCalculationHandler : PriceTypeCalculationHandler
    {
        internal PerUnitPriceCalculationHandler() : base()
        { }

        internal PerUnitPriceCalculationHandler(PriceTypeCalculationHandler next) : base(next)
        {
        }

        protected override decimal Calculate(Item item, ref int remainingItemsCount)
        {
            decimal price = 0.0m;

            if (item.PerUnitPrice != null)
            {
                price = remainingItemsCount * item.PerUnitPrice.Value;
                remainingItemsCount = 0;
            }

            return price;
        }
    }
}
