using HesapMakinasi;
namespace CalculateServiceTest;

public class CalculateServiceTest
{
    [Fact]
    public void Add_ShouldSumdTwoInteger_When_HaveTwoInteger()
    {
        CalculateService service = new();
        int response = service.Add(1, 2);

        Assert.Equal(3, response);
        Assert.NotEqual(4, response);
    }

    [Fact]
    public void Subtract_ShouldSubtractTwoInteger_When_HaveToInteger()
    {
        CalculateService service = new();
        int response = service.Subtract(3, 1);
        Assert.Equal(2, response);

    }


    [Fact]
    public void Divide_ShouldThrowArgumentException_When_SecondParamaterValueýfZero()
    {
        CalculateService calculateService = new();
        Action action = () => calculateService.Divide(1, 0);
        Assert.Throws<ArgumentException>(action);
    }


}