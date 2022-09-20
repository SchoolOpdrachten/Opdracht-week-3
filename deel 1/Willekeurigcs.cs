namespace Program;

public static class Willekeurig
{
    
    public static Random Random = new Random();
    public static async Task Pauzeer(int milliSeconden, double willekeurigheid = .3)
    {
        await Task.Delay((int)(milliSeconden * (1 + willekeurigheid * (2 * Random.NextDouble() - 1))));
    }
}