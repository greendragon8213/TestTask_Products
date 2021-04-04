namespace TestTask_Products
{
    abstract class PriceTypeCalculationHandler
    {
        protected PriceTypeCalculationHandler _nextHandler { get; set; }

        public PriceTypeCalculationHandler()
        { }

        public PriceTypeCalculationHandler(PriceTypeCalculationHandler next)
        {
            _nextHandler = next;
        }

        public virtual decimal Handle(Item item, ref int remainingItemsCount)
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
