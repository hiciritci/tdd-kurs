using HesapMakinasi;

namespace HesapManinasi.Tests.UnitTest;
public sealed class CalculateServiceTest : IClassFixture<CalculateServiceFixture> //Bir kere çalışıyor her metot için ayrı ayrı servisi tetiklemiyor.
{
    private readonly CalculateService _sut;
    public CalculateServiceTest(CalculateServiceFixture fixture)
    {
        _sut = fixture.calculateService;
    }

    [Fact]
    public void Add_ShouldSumTwoInteger_When_HaveTwoInteger()
    {
        //// Arrange
        //CalculateService calculateService = new();

        // Act
        int response = _sut.Add(1, 2);

        // Assert
        Assert.Equal(3, response);
        Assert.NotEqual(4, response);
    }

    [Fact]
    public void Subtract_ShouldSubtractTwoInteger_When_HaveToInteger()
    {
        int response = _sut.Subtract(3, 1);

        Assert.Equal(2, response);
    }

    [Fact]
    public void Divide_ShouldThrowArgumentException_When_SecondParameterValueIfZero()
    {
        Action action = () => _sut.Divide(1, 0);

        Assert.Throws<DivideException>(action);
    }

    [Fact]
    public void Divide_ShouldDivideTwoInteger_When_HaveTwoInteger()
    {
        int response = _sut.Divide(4, 2);
        Assert.Equal(2, response);
    }

    [Fact]
    public void Multiply_ShouldMultiplyTwoInteger_When_HaveTwoInteger()
    {
        int response = _sut.Multiply(2, 3);
        Assert.Equal(6, response);
    }

    // başarılı bölme testi yazın
    // çarpma metodu ekledin
    // başarılı çarpma testi yazın
}
