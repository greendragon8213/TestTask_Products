namespace TestTask_Products.PriceCalculations
{
    public  class PriceCalculationChain
    {
        private readonly PriceTypeCalculationHandler _calculationChain = 
            new PerGroupPriceCalculationHandler(new PerUnitPriceCalculationHandler());

        //ToDo: mb rename to Calculate or smth?
        public decimal Calculate(Item item)
        {
            var remainingItemsCount = item.Count;
            return _calculationChain.Handle(item, ref remainingItemsCount);
        }
    }
}
