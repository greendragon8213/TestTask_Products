namespace TestTask_Products
{
    class PerGroupPriceCalculationHandler : PriceTypeCalculationHandler
    {
        public PerGroupPriceCalculationHandler() : base()
        { }

        public PerGroupPriceCalculationHandler(PriceTypeCalculationHandler next) : base(next)
        {
        }

        protected override void Calculate(Item item)
        {
            if (item.PerGroupPrice != null)
            {
                int groupsCount = GetGroupsCount(item);
                item.TotalPrice += groupsCount * item.PerGroupPrice.Value;
                item.RemainingCount -= groupsCount * item.PerGroupPrice.ItemsInGroupCount;
            }
        }

        private int GetGroupsCount(Item item) => item.RemainingCount / item.PerGroupPrice.ItemsInGroupCount;
    }
}
