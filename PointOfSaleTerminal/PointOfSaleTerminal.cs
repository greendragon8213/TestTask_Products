using System;
using System.Collections.Generic;
using System.Linq;
using TestTask_Products;
using TestTask_Products.PriceCalculations;

namespace PointOfSaleTerminal
{
    public class PointOfSaleTerminal
    {
        protected ProductService _productService;
        protected PriceCalculator _priceCalculator;

        protected IDictionary<string, int> _scannedProducts = new Dictionary<string, int>();

        public PointOfSaleTerminal(ProductService productService, PriceCalculator priceCalculator)
        {
            _productService = productService;
            _priceCalculator = priceCalculator;
        }

        public void RegisterProduct(Product product)
        {
            _productService.Create(product);
        }

        public void Scan(string id)
        {
            if (!_productService.Exist(id))
                throw new ArgumentException($"Product with id {id} doesn't exist");

            if (_scannedProducts.ContainsKey(id))
                _scannedProducts[id]++;
            else
                _scannedProducts.Add(id, 1);
        }

        public double CalculateTotal()
        {
            var products = _productService.Get(p => _scannedProducts.Keys.Any(key => key == p.Id)).ToList();

            var calculationItems = products.Select(p => 
                new PriceCalculationItem(p.Id, _scannedProducts[p.Id], p.PerUnitPrice) 
                { 
                    PerGroupPrice = p.PerGroupPrice 
                });

            return (double)_priceCalculator.CalculateTotal(calculationItems);
        } 

        public void Reset()
        {
            _scannedProducts.Clear();
        }
    }
}
