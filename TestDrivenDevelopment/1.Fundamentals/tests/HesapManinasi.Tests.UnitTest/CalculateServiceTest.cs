using HesapMakinasi;

namespace HesapManinasi.Tests.UnitTest;
public sealed class CalculateServiceTest : IClassFixture<CalculateServiceFixture>
//Bir kere çalışıyor her metot için ayrı ayrı servisi tetiklemiyor.
{
    private readonly CalculateService _sut;
    public CalculateServiceTest(CalculateServiceFixture fixture)
    {
        _sut = fixture.calculateService;
    }


    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(3, 5, 8)]
    [InlineData(8, 2, 10)]
    /// Aynı metotdu test ederken her sefreinde farklı servis yazmak yerine bu şekilde farklı datalar     gönderebiliriz. InlineData

    public void Add_ShouldSumTwoInteger_When_HaveTwoInteger(int x, int y, int excepted)
    {
        //// Arrange
        //CalculateService calculateService = new();

        // Act
        int response = _sut.Add(x, y);

        // Assert
        Assert.Equal(excepted, response);
        Assert.NotEqual(excepted + 1, response);
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
