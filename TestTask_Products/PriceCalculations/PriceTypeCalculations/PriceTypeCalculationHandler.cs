namespace TestTask_Products.PriceCalculations
{
    abstract class PriceTypeCalculationHandler
    {
        protected PriceTypeCalculationHandler _nextHandler { get; set; }

        internal PriceTypeCalculationHandler()
        { }

        internal PriceTypeCalculationHandler(PriceTypeCalculationHandler next)
        {
            _nextHandler = next;
        }

        internal virtual decimal Handle(Item item, ref int remainingItemsCount)
        {
            if (remainingItemsCount <= 0)
                return 0.0m;

            var totalPrice = Calculate(item, ref remainingItemsCount);

            totalPrice += _nextHandler?.Handle(item, ref remainingItemsCount) ?? 0.0m;

            return totalPrice;
        }

        protected abstract decimal Calculate(Item item, ref int remainingItemsCount);
    }
}
