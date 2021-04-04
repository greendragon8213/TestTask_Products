namespace TestTask_Products.Domain.PriceCalculations
{
    public  class PriceCalculationChain
    {
        private readonly PriceTypeCalculationHandler _calculationChain = 
            new PerGroupPriceCalculationHandler(new PerUnitPriceCalculationHandler());

        public decimal Calculate(PriceCalculationItem item)
        {
            var remainingItemsCount = item.Count;
            return _calculationChain.Handle(item, ref remainingItemsCount);
        }
    }
}
