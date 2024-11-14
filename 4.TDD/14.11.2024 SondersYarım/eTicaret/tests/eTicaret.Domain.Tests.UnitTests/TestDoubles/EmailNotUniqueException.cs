namespace eTicaret.Domain.Tests.UnitTests.TestDoubles;

public sealed class EmailNotUniqueException : Exception
{
    public EmailNotUniqueException() : base("Mail adresi daha önce kullanılmış")
    {

    }

    //public implicit operator (Arastırılması gerekiyor güzel bir obje tanımlama)
}