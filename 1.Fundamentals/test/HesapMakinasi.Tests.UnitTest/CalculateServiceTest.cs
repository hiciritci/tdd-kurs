using HesapMakinasi;
namespace CalculateServiceTest;

public sealed class CalculateServiceTest
{
    private readonly CalculateService calcService;

    public CalculateServiceTest()
    {
        calcService = new();
    }

    [Fact]
    public void Add_ShouldSumdTwoInteger_When_HaveTwoInteger()
    {
        // Arrenge

        // Act 
        int response = calcService.Add(1, 2);

        //Assert
        Assert.Equal(3, response);
        Assert.NotEqual(4, response);
    }

    [Fact]
    public void Subtract_ShouldSubtractTwoInteger_When_HaveToInteger()
    {
        int response = calcService.Subtract(3, 1);
        Assert.Equal(2, response);
    }

    [Fact]
    public void Divide_ShouldThrowArgumentException_When_SecondParamaterValueýfZero()
    {

        Action action = () => calcService.Divide(1, 0);
        Assert.Throws<DivideException>(action);
    }

    [Fact]
    public void Divide_ShoulDivide()
    {

        int response = calcService.Divide(4, 2);
        Assert.Equal(2, response);
    }

    [Fact]
    public void Multiplication_ShuldMultiplicationTwoInteger_When_HaveToInteger()
    {

        int response = calcService.Multiplication(8, 2);
        Assert.Equal(16, response);
    }
}