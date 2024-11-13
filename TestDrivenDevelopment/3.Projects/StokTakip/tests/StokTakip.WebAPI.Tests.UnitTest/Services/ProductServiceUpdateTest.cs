using FluentAssertions;
using FluentValidation;
using StokTakip.WebAPI.Dtos;
using StokTakip.WebAPI.Services;

namespace StokTakip.WebAPI.Tests.UnitTest.Services;
public sealed class ProductServiceUpdateTest : IClassFixture<ProductServiceFixture>
{
    private readonly ProductServiceFixture _fixture;
    private readonly ProductService _sut;

    public ProductServiceUpdateTest(ProductServiceFixture fixture)
    {
        _fixture = fixture;
        _sut = fixture.productService;
    }

    [Fact]
    public async Task Update_Should_Throw_ValitadionException_Id_Name_Less_Than_3_Characters()
    {
        //Arrange
        UpdateProductDto request = new(Guid.NewGuid(), "ab", 1, 1);

        //Act
        var action = async () => await _sut.UpdateAsync(request, CancellationToken.None);
        //Assert

        var exception = await action.Should().ThrowAsync<ValidationException>();

        exception.Which.Errors.First().ErrorMessage.Should().Contain("Ürün");
        exception.Which.Errors.Should().HaveCount(1);

    }

    [Fact]
    public async Task Update_Should_Throw_ValitadionException_If_Price_Less_Or_Equels_Zero()
    {
        //Arrange
        UpdateProductDto request = new(Guid.NewGuid(), "ab", 1, 0);

        //Act
        var action = async () => await _sut.UpdateAsync(request, CancellationToken.None);
        //Assert

        var exception = await action.Should().ThrowAsync<ValidationException>();

        exception.Which.Errors.First().ErrorMessage.Should().Contain("Birim fiyatı");
        exception.Which.Errors.Should().HaveCount(1);

    }
}
