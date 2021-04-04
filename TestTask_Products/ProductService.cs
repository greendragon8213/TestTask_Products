using System;
using System.Collections.Generic;

namespace TestTask_Products
{
    public class ProductService
    {
        protected IProductStorage _productStorage;

        public ProductService(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }

        public bool Exist(string id) => _productStorage.Exist(id);

        public Product Get(string id) => _productStorage.Get(id);

        public IEnumerable<Product> Get(Func<Product, bool> p) => _productStorage.Get(p);

        public void Create(Product product)
        {
            if (_productStorage.Exist(product.Id))
                throw new InvalidOperationException($"Product with id {product.Id} already exists");

            _productStorage.Create(product);
        }
    }
}
