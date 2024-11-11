namespace TestingTechniques;

public class ValueSamples
{
    public string FullName = "Halil İbrahim CIRITCI";
    public int Age = 31;
    public DateOnly DateOfBirt = new(1993, 01, 07);

    public User AppUser = new()
    {
        FullName = "Halil İbrahim CIRITCI",
        Age = 31,
        DateOfBirt = new(1993, 01, 07),
    };


    public IEnumerable<User> Users = new[]
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


}

public class User
{

    //public string FirstName { get; set; } = default!;
    //public string LastName { get; set; } = default!;
    //public string FullName => string.Join(" ", FirstName, LastName);

    public string FullName { get; set; } = default!;
    public int Age { get; set; }
    public DateOnly DateOfBirt { get; set; }
}