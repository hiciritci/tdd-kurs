using FluentAssertions;

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
}
