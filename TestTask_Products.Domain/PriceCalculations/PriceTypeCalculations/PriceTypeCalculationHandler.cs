using System;

namespace TestTask_Products.Domain.PriceCalculations
{
    abstract class PriceTypeCalculationHandler
    {
        protected PriceTypeCalculationHandler _nextHandler { get; set; }

        protected bool IsLastHandler => _nextHandler == null;

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

            if (IsLastHandler && remainingItemsCount != 0)
                throw new InvalidOperationException($"Couldn't calculate price of {item.ProductId} " +
                    $"for requested items count - {item.Count}. Try calculate for {item.Count - remainingItemsCount} items");

            if(IsLastHandler)
                return totalPrice;

            totalPrice += _nextHandler.Handle(item, ref remainingItemsCount);

            return totalPrice;
        }

        protected abstract decimal Calculate(PriceCalculationItem item, ref int remainingItemsCount);
    }
}
