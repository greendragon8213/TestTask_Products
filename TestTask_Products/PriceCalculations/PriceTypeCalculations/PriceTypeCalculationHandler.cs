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

        public virtual void Handle(Item item)
        {
            if (item == null)
                return; //or throw exception?

            if (item.RemainingCount <= 0)
                return;

            Calculate(item);

            _nextHandler?.Handle(item);
        }

        protected abstract void Calculate(Item item);
    }
}
