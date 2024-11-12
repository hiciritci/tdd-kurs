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

    public static IEnumerable<object[]> Data = new List<object[]>()
    {
        new object[]{ 2, 3, 5 },
        new object[]{ 3, 5, 8 },
    };


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


    [Theory]
    [InlineData(4, 2, 2)]
    [InlineData(10, 0, 0, Skip = "Sıfıra bölünenemez! Bu test atlandı..")]
    [InlineData(8, 2, 4)]
    public void Divide_ShouldDivideTwoInteger_When_HaveTwoInteger(int x, int y, int excepced)
    {
        int response = _sut.Divide(x, y);
        Assert.Equal(excepced, response);
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
