using FluentAssertions;

namespace eTicaret.Domain.Tests.UnitTests;
public sealed class RegisterCommandHandlerTest
{
    [Fact]
    public async Task Register_Should_Throw_Exception_If_Email_Not_Unique()
    {
        //Arrange

        RegisterCommand request = new("Halilİbrahim", "CIRITCI", "halil@gmail.com");
        RegisterCommandHandler handler = new();
        //Act

        var action = async () => await handler.Handle(request, default);

        //Assert 
        var exception = await action.Should().ThrowAsync<Exception>();
        exception.Which.Message.Should().Be("Mail adresi daha önce kulanılmış.");
    }
}

public sealed record RegisterCommand(
    string Val1,
    string Val2,
    string Val3);

public sealed class RegisterCommandHandler
{
    public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        throw new Exception("Mail adresi daha önce kulanılmış.");
    }
}

