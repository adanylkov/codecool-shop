using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using NSubstitute;

namespace CodecoolShopTests;

public class ProductServiceTests
{
    private IProductCategoryDao _categoryDao;
    private IProductDao _productDao;
    private ProductService _productService;
    private ISupplierDao _supplierDao;

    [SetUp]
    public void Setup()
    {
        _categoryDao = Substitute.For<IProductCategoryDao>();
        _supplierDao = Substitute.For<ISupplierDao>();
        _productDao = Substitute.For<IProductDao>();
        _productService = new ProductService(_productDao, _categoryDao, _supplierDao);
    }
    [Test]
    public void GetProductCategoryTests()
    {
        //Arrange

        var category = new ProductCategory { Id = 1, Name = "TestCategory" };
        _categoryDao.Get(category.Id).Returns(category);

        //Act

        var result = _productService.GetProductCategory(1);

        //Assert

        Assert.That(result, Is.EqualTo(category));
    }
    [Test]
    public void GetProductForCategoryTests()
    {
        //Arrange 

        var category = new ProductCategory { Id = 1, Name = "TestCategory" };
        _categoryDao.Get(category.Id).Returns(category);
        IEnumerable<Product> products = new List<Product>
        {
            new() {Id = 1, Name = "FirstProduct"},
            new() {Id = 2, Name = "SecondProduct"},
            new() {Id = 3, Name = "ThirdProduct"}
        };
        _productDao.GetBy(category).Returns(products);

        //Act

        var result = _productService.GetProductsForCategory(1);

        //Assert

        Assert.That(result, Is.EqualTo(products));
    }
    [Test]
    public void GetProductForSupplierTest()
    {
        //Arrange

        var supplier = new Supplier { Id = 1, Name = "TestSupplier" };
        _supplierDao.Get(supplier.Id).Returns(supplier);
        IEnumerable<Product> products = new List<Product>
        {
            new() {Id = 1, Name = "FirstProduct"},
            new() {Id = 2, Name = "SecondProduct"},
            new() {Id = 3, Name = "ThirdProduct"}
        };
        _productDao.GetBy(supplier).Returns(products);

        //Act

        var result = _productService.GetProductsForSupplier(1);

        //Assert

        Assert.That(result, Is.EqualTo(products));
    }
    [Test]
    public void GetProductByIdTest()
    {
        //Arrange

        var product = new Product { Id = 1, Name = "TestCategory" };
        _productDao.Get(product.Id).Returns(product);

        //Act

        var result = _productService.GetProductById(1);

        //Assert

        Assert.That(result, Is.EqualTo(product));
    }
    [Test]
    public void GetCategoriesTest()
    {
        //Arrange

        IEnumerable<ProductCategory> categories = new List<ProductCategory>
        {
            new() {Id = 1, Name = "Category1"},
            new() {Id = 2, Name = "Category2"},
            new() {Id = 3, Name = "Category3"}
        };
        _categoryDao.GetAll().Returns(categories);

        //Act

        var result = _productService.GetCategories();

        //Assert

        Assert.That(result, Is.EqualTo(categories));
    }
    [Test]
    public void GetSuppliersTest()
    {
        //Arrange

        IEnumerable<Supplier> suppliers = new List<Supplier>
        {
            new() {Id = 1, Name = "Supplier1"},
            new() {Id = 2, Name = "Supplier2"},
            new() {Id = 3, Name = "Supplier3"}
        };
        _supplierDao.GetAll().Returns(suppliers);

        //Act

        var result = _productService.GetSupliers();

        //Assert

        Assert.That(result, Is.EqualTo(suppliers));
    }

}
