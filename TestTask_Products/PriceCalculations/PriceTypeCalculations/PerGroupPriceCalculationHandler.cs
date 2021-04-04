﻿namespace TestTask_Products.PriceCalculations
{
    class PerGroupPriceCalculationHandler : PriceTypeCalculationHandler
    {
        internal PerGroupPriceCalculationHandler() : base()
        { }

        internal PerGroupPriceCalculationHandler(PriceTypeCalculationHandler next) : base(next)
        {
        }

        protected override decimal Calculate(Item item, ref int remainingItemsCount)
        {
            decimal price = 0.0m;

            if (item.PerGroupPrice != null)
            {
                var groupsCount = remainingItemsCount / item.PerGroupPrice.ItemsInGroupCount;
                price = groupsCount * item.PerGroupPrice.Value;
                remainingItemsCount -= groupsCount * item.PerGroupPrice.ItemsInGroupCount;
            }

            return price;
        }
    }
}
