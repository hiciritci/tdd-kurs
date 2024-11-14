namespace eTicaret.Domain.Tests.UnitTests.TestDoubles;

public class StubUniqeEmailUserRepository : IUserRepository
{
    public Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(false);

    }
}
