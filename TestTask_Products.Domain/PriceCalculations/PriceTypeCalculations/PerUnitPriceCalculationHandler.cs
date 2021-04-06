namespace TestTask_Products.Domain.PriceCalculations
{
    class PerUnitPriceCalculationHandler : PriceTypeCalculationHandler
    {
        internal PerUnitPriceCalculationHandler() : base()
        { }

        internal PerUnitPriceCalculationHandler(PriceTypeCalculationHandler next) : base(next)
        {
        }

        protected override decimal Calculate(PriceCalculationItem item, ref int remainingItemsCount)
        {
            var price = 0.0m;

            if (item.PerUnitPrice != null)
            {
                price = remainingItemsCount * item.PerUnitPrice.Value;
                remainingItemsCount = 0;
            }

            return price;
        }
    }
}
