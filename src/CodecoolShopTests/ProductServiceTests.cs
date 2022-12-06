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
    public void GetProductCategory_Test()
    {
        //Arrange

        var category = new ProductCategory { Id = 1, Name = "TestCategory" };
        _categoryDao.Get(category.Id).Returns(category);

        //Act

        var result = _productService.GetProductCategory(1);

        //Assert

        Assert.That(result, Is.EqualTo(category));
    }

}
