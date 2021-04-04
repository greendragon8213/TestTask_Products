using System;

namespace TestTask_Products
{
    public class Product
    {
        protected string _id;

        public Product(string id, PerUnitPrice perUnitPrice)
        {
            Id = id;
            PerUnitPrice = perUnitPrice;
        }

        public string Id
        {
            get => _id;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException();

                _id = value;
            }
        }

        public string Name { get; set; }

        public PerUnitPrice PerUnitPrice { get; set; }
        public PerGroupPrice PerGroupPrice { get; set; }
    }
}
