using System.Net.Http.Json;
using Bogus;
using FluentAssertions;
using StokTakip.WebAPI.Dtos;
using StokTakip.WebAPI.Models;

namespace StokTakip.WebAPI.Tests.IntegrationTest;
public sealed class ProductEndPointsTest
{
    [Fact]
    public async Task GetAll_Should_Return_StatusCode_200_When_There_Is_No_Error()
    {
        //Arrange
        HttpClient httpClient = new HttpClient()
        { BaseAddress = new Uri("https://localhost:58431") };

        //Act
        var message = await httpClient.GetAsync("/products");

        //Assert
        message.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

    }

    [Fact]
    public async Task Create_Should_Return_StatusCode_200_If_Request_Is_Valid_And_Name_Is_Unique()
    {
        //Arrenge
        Faker faker = new Faker(); //BOGUS Kütüphanesi
        CreateProductDto request = new(
            faker.Commerce.ProductName(),
            faker.Random.Number(1, 20),
            Convert.ToDecimal(faker.Commerce.Price(1, 15000)));
        HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:58431")
        };
        //Act
        var message = await httpClient.PostAsJsonAsync("/products", request, default);
        //Assert
        message.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        Product? product = await message.Content.ReadFromJsonAsync<Product>();
        product.Should().NotBeNull();
        product!.Name.Should().Be(request.Name);
    }
}
