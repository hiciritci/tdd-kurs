namespace HesapMakinasi;
public class CalculateService
{
    public int Add(int x, int y) { return x + y; }

    public int Subtract(int x, int y) { return x - y; }

    public int Divide(int x, int y)
    {
        if (y == 0)
        {
            throw new ArgumentException("0 Bölünemez !");
        };
        return x / y;
    }
}
