namespace eTicaret.Domain.Entities;
public sealed class User
{
    public string FirtName { get; private set; } = default!;
    public void SetName(string firtname)
    {
        if (firtname.Length < 3)
        {
            throw new Exception();
        }
        FirtName = firtname;
    }
}

