using System;

namespace TestTask_Products
{
    public class PerGroupPrice : Price
    {
        protected int _itemsInGroupCount;

        public PerGroupPrice(decimal value, int itemsGroupCount) : base(value)
        {
            ItemsInGroupCount = itemsGroupCount;
        }

        public int ItemsInGroupCount
        {
            get => _itemsInGroupCount;
            set
            {
                if (value <= 0)
                    throw new ArgumentException();

                _itemsInGroupCount = value;
            }
        }
    }
}