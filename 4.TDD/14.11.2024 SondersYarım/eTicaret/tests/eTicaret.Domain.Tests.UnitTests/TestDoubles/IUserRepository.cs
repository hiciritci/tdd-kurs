namespace eTicaret.Domain.Tests.UnitTests.TestDoubles;

public interface IUserRepository
{
    Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken = default);
}
