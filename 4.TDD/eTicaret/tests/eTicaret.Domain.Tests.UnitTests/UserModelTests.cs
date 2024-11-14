using FluentAssertions;
namespace eTicaret.Domain.Tests.UnitTests;
public sealed class UserModelTests
{
    [Fact]
    public void FirstName_Should_Throw_Exception_If_Less_Than_3_Characters()
    {
        //Arrange
        User user = new();

        //Act
        var action = () => user.SetName("Ha");

        //Assert
        action.Should().Throw<Exception>();

    }

    [Fact]
    public void FirstName_Should_Not_Throw_Exception_If_Greater_Than_2_Characters()
    {
        //Arrange
        User user = new();

        //Act
        var action = () => user.SetName("Halil");

        //Assert
        action.Should().NotThrow<Exception>();
    }
}
public sealed class User
{
    public void SetName(string firtname)
    {
        if (firtname.Length < 3)
        {
            throw new Exception();
        }

    }
}