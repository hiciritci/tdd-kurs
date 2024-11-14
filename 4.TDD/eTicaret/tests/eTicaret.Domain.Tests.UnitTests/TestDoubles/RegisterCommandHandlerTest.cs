using FluentAssertions;

namespace eTicaret.Domain.Tests.UnitTests.TestDoubles;
public sealed class RegisterCommandHandlerTest
{
    [Fact]
    public async Task Register_Should_Throw_EmailNotUniqueException_If_Email_Not_Unique()
    {
        // Arrange
        RegisterCommand request = new("Halil", "Ciritci", "hc@gmail.com");

        IUserRepository userRepository = new StubNotuniqeEmailUserRepository();
        RegisterCommandHandler handler = new(userRepository);

        // Act
        var action = async () => await handler.Handle(request, default);

        // Assert
        var exception = await action.Should().ThrowAsync<EmailNotUniqueException>();
        exception.Which.Message.Should().Be("Mail adresi daha önce kullanılmış");
    }

    [Fact]
    public async Task Register_Should_Not_Throw_Exception_If_Email_Unique()
    {
        // Arrange
        RegisterCommand request = new("Halil", "Ciritci", "hc@gmail.com");
        IUserRepository userRepository = new StubUniqeEmailUserRepository();
        RegisterCommandHandler handler = new(userRepository);

        // Act
        var action = async () => await handler.Handle(request, default);

        // Assert
        var exception = await action.Should().NotThrowAsync<EmailNotUniqueException>();

    }
}

public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string Email);

public sealed class RegisterCommandHandler(IUserRepository userRepository)
{
    public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        bool isEmailExists = await userRepository.IsEmailExistsAsync(request.Email, cancellationToken);
        if (isEmailExists)
        {
            throw new EmailNotUniqueException();
        }
    }
}
