using HesapMakinasi;
namespace TestProject1;

public class CalculateServiceTest
{
    [Fact]
    public void Add_ShouldSumdTwoInteger_When_HaveTwoInteger()
    {
        CalculateService service = new();
        var response = service.Add(1, 2);

        Assert.Equal(response, 3);
        Assert.NotEqual(response, 4);
        Assert.NotNull(response);


    }
}