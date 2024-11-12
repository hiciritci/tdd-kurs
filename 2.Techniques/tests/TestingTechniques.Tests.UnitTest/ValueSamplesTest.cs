using AutoFixture;
using Bogus;
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

        fullName.Should().Be("Halil İbrahim CIRITCI");
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

    [Fact]
    public void ObjectAssertionExample()
    {
        //Arrange
        Fixture fixture = new();
        //automatik model den nesne olusturuyor fakat anlamlı bir sonuc üretmiyor.
        var user2 = fixture.Create<User>();

        /// bu da auto dolduryor veriler daha amantıklı geliyor. Örnegin ad-soyad verileri gercekci.
        Faker faker = new();

        //User2 user3 = faker.Generate();

        var user = _sut.AppUser;

        var excepted = new User()
        {
            FullName = "Halil İbrahim CIRITCI",
            Age = 31,
            DateOfBirt = new(1993, 01, 07)
        };

        //Assert
        user.Should().BeEquivalentTo(excepted);
        user.FullName.Should().Be(excepted.FullName);
        user.Age.Should().Be(excepted.Age);
    }

    [Fact]
    public void ListAsserionExample()
    {
        //Arrange
        var users = _sut.Users;
        var excepted = new List<User>()
        {
             new User()
        {
            FullName="Halil İbrahim CIRITCI",
            Age = 31,
            DateOfBirt=new(1993,01,07)
        },

           new User()
        {
            FullName="Hasan CIRITCI",
            Age = 67,
            DateOfBirt=new(1957,01,15)
        }

        };

        users.Should().BeEquivalentTo(excepted);
        users.Should().HaveCount(2);
        users.First().FullName.Should().Be(excepted.First().FullName);
    }
}