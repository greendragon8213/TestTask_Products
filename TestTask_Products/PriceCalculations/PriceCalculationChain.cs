namespace TestTask_Products.PriceCalculations
{
    public  class PriceCalculationChain
    {
        private readonly PriceTypeCalculationHandler _calculationChain = 
            new PerGroupPriceCalculationHandler(new PerUnitPriceCalculationHandler());

        public void Handle(Item item)
        {
            _calculationChain.Handle(item);
        }
    }
}
