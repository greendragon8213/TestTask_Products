using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTask_Products;
using TestTask_Products.DataAccess;
using TestTask_Products.Domain;
using TestTask_Products.Domain.PriceCalculations;
using TestTask_Products.Terminals;

namespace Tests
{
    //These tests are not usual unit tests, they are just automated tests to prove it all works
    [TestClass]
    public class PriceCalculationTests
    {
        private static ProductService _productService;
        private static PriceCalculator _priceCalculator;

        [AssemblyInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            var productStorage = new InMemoryProductStorage();
            _productService = new ProductService(productStorage);

            var priceCalculationChain = new PriceCalculationChain();
            _priceCalculator = new PriceCalculator(priceCalculationChain);

            InitializeProductStorage();
        }

        private static void InitializeProductStorage()
        {
            _productService.Create(new Product("A", new PerUnitPrice(1.25m)) { PerGroupPrice = new PerGroupPrice(3.00m, 3) });
            _productService.Create(new Product("B", new PerUnitPrice(4.25m)));
            _productService.Create(new Product("C", new PerUnitPrice(1.00m)) { PerGroupPrice = new PerGroupPrice(5.00m, 6) });
            _productService.Create(new Product("D", new PerUnitPrice(0.75m)));
        }

        [TestMethod]
        public void TotalPriceIsEqualTo13_25_IfItemsScannedInOrderABCDABA()
        {
            //Arrange
            var pointOfSaleTerminal = new PointOfSaleTerminal(_productService, _priceCalculator);
            pointOfSaleTerminal.Reset();

            pointOfSaleTerminal.Scan("A");
            pointOfSaleTerminal.Scan("B");
            pointOfSaleTerminal.Scan("C");
            pointOfSaleTerminal.Scan("D");
            pointOfSaleTerminal.Scan("A");
            pointOfSaleTerminal.Scan("B");
            pointOfSaleTerminal.Scan("A");

            //Act
            var price = pointOfSaleTerminal.CalculateTotal();

            //Assert
            Assert.AreEqual(13.25m, price);
        }
        
        [TestMethod]
        public void TotalPriceIsEqualTo6_IfItemsScannedInOrderCCCCCCC()
        {
            //Arrange
            var pointOfSaleTerminal = new PointOfSaleTerminal(_productService, _priceCalculator);
            pointOfSaleTerminal.Reset();

            pointOfSaleTerminal.Scan("C");
            pointOfSaleTerminal.Scan("C");
            pointOfSaleTerminal.Scan("C");
            pointOfSaleTerminal.Scan("C");
            pointOfSaleTerminal.Scan("C");
            pointOfSaleTerminal.Scan("C");
            pointOfSaleTerminal.Scan("C");

            //Act
            var price = pointOfSaleTerminal.CalculateTotal();

            //Assert
            Assert.AreEqual(6.00m, price);
        }

        [TestMethod]
        public void TotalPriceIsEqualTo7_25_IfItemsScannedInOrderABCD()
        {
            //Arrange
            var pointOfSaleTerminal = new PointOfSaleTerminal(_productService, _priceCalculator);
            pointOfSaleTerminal.Reset();

            pointOfSaleTerminal.Scan("A");
            pointOfSaleTerminal.Scan("B");
            pointOfSaleTerminal.Scan("C");
            pointOfSaleTerminal.Scan("D");

            //Act
            var price = pointOfSaleTerminal.CalculateTotal();

            //Assert
            Assert.AreEqual(7.25m, price);
        }
    }
}
