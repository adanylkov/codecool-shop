using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Domain;

namespace CodecoolShopTests
{
    public class Tests
    {
        private Cart _cart;
        private IProductDao _productDataStore;
        [SetUp]
        public void Setup()
        {
            _cart = new Cart();
            _productDataStore = new ProductDaoMemory(new ProductCategoryDaoMemory(), new SupplierDaoMemory());
            var products = _productDataStore.GetAll().ToList();
            foreach (var product in products)
            {
                _productDataStore.Remove(product.Id);
            }
        }

        [Test]
        public void AddedProductIsInCart()
        {
            var product1 = new Product
            {
                Name = "Amazon Fire",
                DefaultPrice = 49.9m,
                Currency = "USD",
                Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.",
            };
            _productDataStore.Add(product1);

            _cart.Add(product1);
            var actualCart = _cart.GetAll();
            var expectedCart = new KeyValuePair<int, int>[] { new KeyValuePair<int, int>(product1.Id, 1) };

            CollectionAssert.AreEqual(actualCart, expectedCart);
        }
        [Test]
        public void SameProductAddedMultipleTimesAppearsOneTimeInCart()
        {
            var product1 = new Product
            {
                Name = "Amazon Fire",
                DefaultPrice = 49.9m,
                Currency = "USD",
                Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.",
            };
            _productDataStore.Add(product1);

            _cart.Add(product1);
            _cart.Add(product1);


            var actualCartSize = _cart.GetAll().Count();
            var expectedCartSize = 1;

            Assert.That(actualCartSize, Is.EqualTo(expectedCartSize));
        }
        [Test]
        public void ProductAddedMultipleTimesIncreaseCartQuanity()
        {
            var product1 = new Product
            {
                Name = "Amazon Fire",
                DefaultPrice = 49.9m,
                Currency = "USD",
                Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.",
            };
            _productDataStore.Add(product1);

            _cart.Add(product1);
            _cart.Add(product1);


            var actualCart = _cart.GetAll();
            var expectedCart = new KeyValuePair<int, int>[] { new KeyValuePair<int, int>(product1.Id, 2) };

            CollectionAssert.AreEqual(actualCart, expectedCart);
        }
        [Test]
        public void TwoDifferentProductsAddedToCartAsDifferentProducts()
        {
            var product1 = new Product
            {
                Name = "Amazon Fire",
                DefaultPrice = 49.9m,
                Currency = "USD",
                Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.",
            };
            var product2 = new Product
            {
                Name = "Amazon Fire HD 8",
                DefaultPrice = 89.0m,
                Currency = "USD",
                Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.",
            };
            _productDataStore.Add(product1);
            _productDataStore.Add(product2);

            _cart.Add(product1);
            _cart.Add(product2);


            var actualCartSize = _cart.GetAll().Count();
            var expectedCartSize = 2;

            Assert.That(actualCartSize, Is.EqualTo(expectedCartSize));

        }
        [Test]
        public void DifferentProductsAddedToCartMultipleTimesAffectsQuanityOnDifferentProduct()
        {
            var product1 = new Product
            {
                Name = "Amazon Fire",
                DefaultPrice = 49.9m,
                Currency = "USD",
                Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.",
            };
            var product2 = new Product
            {
                Name = "Amazon Fire HD 8",
                DefaultPrice = 89.0m,
                Currency = "USD",
                Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.",
            };
            _productDataStore.Add(product1);
            _productDataStore.Add(product2);

            _cart.Add(product1);
            _cart.Add(product1);
            _cart.Add(product2);


            var actualCart = _cart.GetAll();
            var expectedCart = new KeyValuePair<int, int>[] { new KeyValuePair<int, int>(product1.Id, 2), new KeyValuePair<int, int>(product2.Id, 1) };

            CollectionAssert.AreEqual(actualCart, expectedCart);
        }
        [Test]
        public void RemovedProductFromCartIsNotInIt()
        {
            var product1 = new Product
            {
                Name = "Amazon Fire",
                DefaultPrice = 49.9m,
                Currency = "USD",
                Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.",
            };
            _productDataStore.Add(product1);

            _cart.Add(product1);
            _cart.Add(product1);
            _cart.Remove(product1.Id);

            var actualCart = _cart.GetAll();
            var expectedCart = new KeyValuePair<int, int>[] { };

            CollectionAssert.AreEqual(actualCart, expectedCart);

        }
        [Test]
        public void DecreasingQuanityChangesAmountInCart()
        {
            var product1 = new Product
            {
                Name = "Amazon Fire",
                DefaultPrice = 49.9m,
                Currency = "USD",
                Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.",
            };
            _productDataStore.Add(product1);

            _cart.Add(product1);
            _cart.Add(product1);
            _cart.SetQuanity(product1.Id, 1);

            var actualCart = _cart.GetAll();
            var expectedCart = new KeyValuePair<int, int>[] { new KeyValuePair<int, int>(product1.Id, 1) };

            CollectionAssert.AreEqual(actualCart, expectedCart);
        }
        [Test]
        public void IncreasingQuanityChangesAmountInCart()
        {
            var product1 = new Product
            {
                Name = "Amazon Fire",
                DefaultPrice = 49.9m,
                Currency = "USD",
                Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.",
            };
            _productDataStore.Add(product1);

            _cart.Add(product1);
            _cart.Add(product1);
            _cart.SetQuanity(product1.Id, 3);

            var actualCart = _cart.GetAll();
            var expectedCart = new KeyValuePair<int, int>[] { new KeyValuePair<int, int>(product1.Id, 3) };

            CollectionAssert.AreEqual(actualCart, expectedCart);
        }
        [Test]
        public void DecreasingQuanityToZeroRemovesProductFromCart()
        {
            var product1 = new Product
            {
                Name = "Amazon Fire",
                DefaultPrice = 49.9m,
                Currency = "USD",
                Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.",
            };
            _productDataStore.Add(product1);

            _cart.Add(product1);
            _cart.Add(product1);
            _cart.SetQuanity(product1.Id, 0);

            var actualCart = _cart.GetAll();
            var expectedCart = new KeyValuePair<int, int>[] { };

            CollectionAssert.AreEqual(actualCart, expectedCart);
        }
        [Test]
        public void DecreasingQuanityBelowZeroRemovesProductFromCart()
        {
            var product1 = new Product
            {
                Name = "Amazon Fire",
                DefaultPrice = 49.9m,
                Currency = "USD",
                Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.",
            };
            _productDataStore.Add(product1);

            _cart.Add(product1);
            _cart.SetQuanity(product1.Id, -1);

            var actualCart = _cart.GetAll();
            var expectedCart = new KeyValuePair<int, int>[] { };

            CollectionAssert.AreEqual(actualCart, expectedCart);
        }
    }
}