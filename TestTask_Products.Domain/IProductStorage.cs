using System;
using System.Collections.Generic;

namespace TestTask_Products.Domain
{
    public interface IProductStorage
    {
        Product Get(string id);
        void Create(Product product);
        bool Exist(string id);
        IEnumerable<Product> Get(Func<Product, bool> p);
    }
}
