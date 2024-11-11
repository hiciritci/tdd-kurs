using FluentAssertions;

namespace TestingTechniques.Tests.UnitTest;

public class ValueSamplesTest
{
    private readonly ValueSamples _sut; //System under

    public ValueSamplesTest()
    {
        _sut = new();
    }

    [Fact]
    public void StringAssertionExample()
    {
        //Arrange
        string fullName = _sut.FullName;

        //Assert

        fullName.Should().Be("Halil Ýbrahim CIRITCI");
        fullName.Should().NotBeEmpty();
        fullName.Should().StartWith("Ha");
        fullName.Should().EndWith("I");

    }

    [Fact]
    public void NumbersAssertionExample()
    {
        //Arrange
        int age = _sut.Age;

        // Assert
        age.Should().Be(31);
        age.Should().BePositive();
        age.Should().BeGreaterThan(20);
        age.Should().BeLessThanOrEqualTo(32);
        age.Should().BeInRange(20, 50);
    }

    [Fact]
    public void DateAssertionExample()
    {
        var dateOfBirt = _sut.DateOfBirt;

        //Assert
        dateOfBirt.Should().Be(new(1993, 01, 07));
        // dateOfBirt.Should().BeAfter
    }
}