using System;

namespace TestTask_Products.Domain.PriceCalculations
{
    public class PriceCalculationItem
    {
        protected int _count;
        protected string _productId;

        public PriceCalculationItem(string productId, int count, PerUnitPrice perUnitPrice)
        {
            ProductId = productId;
            Count = count;
            PerUnitPrice = perUnitPrice;
        }

        public string ProductId
        {
            get => _productId;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException();

                _productId = value;
            }
        }

        public PerUnitPrice PerUnitPrice { get; set; }
        public PerGroupPrice PerGroupPrice { get; set; }

        public int Count
        {
            get => _count;
            set
            {
                if (value <= 0)
                    throw new ArgumentException();

                _count = Count;
            }
        }
    }
}
