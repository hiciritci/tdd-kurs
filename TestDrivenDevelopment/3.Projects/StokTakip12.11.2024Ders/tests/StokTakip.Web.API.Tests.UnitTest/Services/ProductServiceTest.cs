using System.Linq.Expressions;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using StokTakip.WebAPI.Dtos;
using StokTakip.WebAPI.Models;
using StokTakip.WebAPI.Services;

namespace StokTakip.WebAPI.Tests.UnitTest.Services;
public sealed class ProductServiceTest : IClassFixture<ProductServiceFixture>
{
    private readonly ProductServiceFixture _fixture;
    private readonly ProductService _sut;

    public ProductServiceTest(ProductServiceFixture fix)
    {
        _fixture = fix;
        _sut = fix.productService;
    }
    [Fact]
    public async Task Create_Should_Throw_ValidationExeption_When_Name_Less_Than_3_Characters()
    {

        CreateProductDto request = new("dm", 1, 1);
        //Act
        var action = async () => await _sut.CreateAsync(request, default);
        //Assert
        var exception = await action.Should().ThrowAsync<ValidationException>();
        exception.Which.Errors.Should().HaveCount(1);
        exception.Which.Errors.First().ErrorMessage.Should().Be("Ürün adı en az 3 karakter olmalıdır");
    }
    [Fact]
    public async Task Create_Should_Throw_ValidationExeption_When_Stock_Is_Zero()
    {

        CreateProductDto request = new("ürün adı", 0, 1);

        //act
        var action = async () => await _sut.CreateAsync(request,
            default);

        //assert
        var exeprtion = await action.Should().ThrowAsync<ValidationException>();
        exeprtion.Which.Errors.Should().HaveCount(1);
        exeprtion.Which.Errors.First().ErrorMessage.Should().Be("Stok adedi 0 dan büyük olmalıdır");

    }
    [Fact]
    public async Task Create_Should_Throw_ValidationExeption_When_Price_Is_Zero()
    {
        CreateProductDto request = new("ürün adı", 10, 0);
        //act
        var action = async () => await _sut.CreateAsync(request,
            default);

        //assert
        var exeprtion = await action.Should().ThrowAsync<ValidationException>();
        exeprtion.Which.Errors.Should().HaveCount(1);
        exeprtion.Which.Errors.First().ErrorMessage.Should().Be("Price adedi 0 dan büyük olmalıdır");

    }

    [Fact]
    public async Task Create_Should_Throw_ArgumentException_When_Name_Already_Exists()
    {
        //Arrange
        CreateProductDto request = new("Bilgisayar", 1, 1);
        _fixture.productRepo.AnyAsync(Arg.Any<Expression<Func<Product, bool>>>(), default).Returns(Task.FromResult(true));

        //act
        var action = async () => await _sut.CreateAsync(request, default);

        //assert

        var exeprtion = await action.Should().ThrowAsync<ArgumentException>();

        exeprtion.Which.Message.Should().Be("Ürün adı daha önce kullanılmış");

    }

    [Fact]
    public async Task Create_should_Convert_dto_obj_when_request_is_valid_and_name_is_unique()
    {
        CreateProductDto request = new("Bilgisayar", 1, 1);

        Product expected = new()
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock
        };

        _fixture.mapper.Map<Product>(Arg.Any<CreateProductDto>()).Returns(expected);

        //act
        await _sut.CreateAsync(request, default);
    }


}