namespace TestTask_Products.Domain.PriceCalculations
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

        internal virtual decimal Handle(PriceCalculationItem item, ref int remainingItemsCount)
        {
            if (remainingItemsCount <= 0)
                return 0.0m;

            var totalPrice = Calculate(item, ref remainingItemsCount);

            if (_nextHandler == null)
                return totalPrice;

            totalPrice += _nextHandler.Handle(item, ref remainingItemsCount);

            return totalPrice;
        }

        protected abstract decimal Calculate(PriceCalculationItem item, ref int remainingItemsCount);
    }
}
