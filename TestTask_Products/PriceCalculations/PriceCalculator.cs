using System.Collections.Generic;
using System.Linq;

namespace TestTask_Products.PriceCalculations
{
    public class PriceCalculator
    {
        private readonly PriceCalculationChain _priceCalculationChain;

        public PriceCalculator(PriceCalculationChain priceCalculationChain)
        {
            _priceCalculationChain = priceCalculationChain;
        }

        public decimal CalculateTotal(IEnumerable<PriceCalculationItem> items)
            => items.Sum(_priceCalculationChain.Calculate);
    }
}