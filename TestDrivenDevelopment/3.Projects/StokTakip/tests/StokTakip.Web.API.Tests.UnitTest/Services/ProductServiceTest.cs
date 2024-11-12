using AutoMapper;
using FluentAssertions;
using GenericRepository;
using NSubstitute;
using StokTakip.WebAPI.Dtos;
using StokTakip.WebAPI.Repositories;
using StokTakip.WebAPI.Services;
using ValidationException = FluentValidation.ValidationException;

namespace StokTakip.Web.API.Tests.UnitTest.Services;
public sealed class ProductServiceTest : IClassFixture<ProductService>
{
    private readonly ProductService productService;

    public ProductServiceTest(ProductService fix)
    {
        productService = fix;
    }

    [Fact]
    public async Task Create_Should_Throw_ValidationException_If_Name_Less_Then_3_Characters()
    {
        /// Arange 
        var productRepository = Substitute.For<IProductRepository>();
        var unitofWork = Substitute.For<IUnitOfWork>();
        var mapper = Substitute.For<IMapper>();
        ProductService productService = new(productRepository, unitofWork, mapper);
        CreateProductDto request = new("HC", 1, 1);

        //Faker<CreateProductDto> faker = new Faker<CreateProductDto>().RuleFor(p => p.Name, f => f.Commerce.ProductName()).RuleFor(p => p.Price, f => Convert.ToDecimal(f.Commerce.Price(1, 1000, 2)));

        //  var request1 = faker.Generate();


        /// Act

        var action = async () => await productService.CreateAsync(request, default);
        /// Assert

        var exception = await action.Should().ThrowAsync<ValidationException>();
        exception.Which.Errors.Should().HaveCount(1);
        exception.Which.Errors.First().ErrorMessage.Should().Be("Ürün adı en az 3 karakter olmalıdır");
    }
    [Fact]
    public async Task Create_Should_Throw_ValidationException_If_Stock_Is_Zero()
    {
        var prodRepo = Substitute.For<IProductRepository>();
        var unit = Substitute.For<IUnitOfWork>();
        var map = Substitute.For<IMapper>();

        ProductService productService = new(prodRepo, unit, map);
        CreateProductDto res = new("adi", 0, 1);
        var act = async () => await productService.CreateAsync(res, default);


        var exc = await act.Should().ThrowAsync<ValidationException>();
        exc.Which.Errors.Should().HaveCount(1);
        exc.Which.Errors.First().ErrorMessage.Should().Be("Stok adedi 0 dan büyük olmalıdır");
    }
}
