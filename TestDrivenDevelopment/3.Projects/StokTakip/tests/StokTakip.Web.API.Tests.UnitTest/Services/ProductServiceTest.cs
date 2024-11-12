using AutoMapper;
using Bogus;
using FluentAssertions;
using GenericRepository;
using NSubstitute;
using StokTakip.WebAPI.Dtos;
using StokTakip.WebAPI.Repositories;
using StokTakip.WebAPI.Services;
using ValidationException = FluentValidation.ValidationException;

namespace StokTakip.Web.API.Tests.UnitTest.Services;
public sealed class ProductServiceTest
{
    [Fact]
    public async Task Create_Should_Throw_ValidationException_If_Name_Less_Then_3_Characters()
    {
        /// Arange 
        var productRepository = Substitute.For<IProductRepository>();
        var unitofWork = Substitute.For<IUnitOfWork>();
        var mapper = Substitute.For<IMapper>();
        ProductService productService = new(productRepository, unitofWork, mapper);
        CreateProductDto request = new("HC", 1, 1);

        Faker<CreateProductDto> faker = new Faker<CreateProductDto>().RuleFor(p => p.Name, f => f.Commerce.ProductName()).RuleFor(p => p.Price, f => Convert.ToDecimal(f.Commerce.Price(1, 1000, 2)));

        //  var request1 = faker.Generate();


        /// Act

        var action = async () => await productService.CreateAsync(request, default);
        /// Assert

        await action.Should().ThrowAsync<ValidationException>();

    }
}
