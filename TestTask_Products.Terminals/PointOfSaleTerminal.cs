using System;
using System.Collections.Generic;
using System.Linq;
using TestTask_Products.Domain;
using TestTask_Products.Domain.PriceCalculations;

namespace TestTask_Products.Terminals
{
    public class PointOfSaleTerminal
    {
        protected readonly ProductService _productService;
        protected readonly PriceCalculator _priceCalculator;

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
            Scan(id, 1);
        }

        public void Scan(string id, int count)
        {
            if (!_productService.Exist(id))
                throw new ArgumentException($"Product with id {id} doesn't exist");

            if (_scannedProducts.ContainsKey(id))
                _scannedProducts[id] += count;
            else
                _scannedProducts.Add(id, count);
        }

        public decimal CalculateTotal()
        {
            var products = _productService.Get(p => _scannedProducts.Keys.Any(key => key == p.Id)).ToList();

            //same as below but with Select instead of join
            //var calculationItems = products.Select(p =>
            //    new PriceCalculationItem(p.Id, _scannedProducts[p.Id], p.PerUnitPrice)
            //    {
            //        PerGroupPrice = p.PerGroupPrice
            //    })
            //.ToList();

            var calculationItems = products.Join(_scannedProducts,
                p => p.Id, sp => sp.Key,
                (product, scannedProduct) =>
                    new PriceCalculationItem(product.Id, scannedProduct.Value, product.PerUnitPrice)
                    {
                        PerGroupPrice = product.PerGroupPrice
                    })
                .ToList();

            return _priceCalculator.CalculateTotal(calculationItems);
        }

        public void Reset()
        {
            _scannedProducts.Clear();
        }
    }
}
