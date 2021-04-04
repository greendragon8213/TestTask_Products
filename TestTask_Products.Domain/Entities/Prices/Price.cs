using System;

namespace TestTask_Products
{
    public abstract class Price
    {
        protected decimal _value;

        public Price(decimal value)
        {
            Value = value;
        }

        public decimal Value 
        { 
            get => _value;
            set 
            {
                if (value <= 0)
                    throw new ArgumentException();

                _value = value;
            }
        }
    }
}
