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

        public decimal Calculate(List<Item> items)
        {
            items.ForEach(_priceCalculationChain.Handle);
            var itemsWithTotalPrice = 

            return items.Sum(i => i.TotalPrice);
        }
    }
}
