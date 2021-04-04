namespace TestTask_Products.PriceCalculations
{
    public  class PriceCalculationChain
    {
        private readonly PriceTypeCalculationHandler _calculationChain = 
            new PerGroupPriceCalculationHandler(new PerUnitPriceCalculationHandler());

        public decimal Calculate(Item item)
        {
            var remainingItemsCount = item.Count;
            return _calculationChain.Handle(item, ref remainingItemsCount);
        }
    }
}
