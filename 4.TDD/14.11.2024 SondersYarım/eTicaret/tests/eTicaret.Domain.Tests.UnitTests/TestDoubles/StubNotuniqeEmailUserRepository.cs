namespace eTicaret.Domain.Tests.UnitTests.TestDoubles;

public class StubNotuniqeEmailUserRepository : IUserRepository
{
    public async Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
        return true;
    }
}
