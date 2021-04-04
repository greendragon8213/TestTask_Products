using System;
using System.Collections.Generic;
using System.Linq;
using TestTask_Products.Domain;

namespace TestTask_Products.DataAccess
{
    public class InMemoryProductStorage : IProductStorage
    {
        private static readonly ICollection<Product> _products = new List<Product>();

        public bool Exist(string id) => _products.Any(p => p.Id == id);

        public Product Get(string id) => _products.FirstOrDefault(p => p.Id == id);
        public IEnumerable<Product> Get(Func<Product, bool> p) => _products.Where(p);

        public void Create(Product product) => _products.Add(product);
    }
}