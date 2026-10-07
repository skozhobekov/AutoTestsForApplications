namespace apitest.Retries;

public static class AdditionalMethod
{
    public static bool RandomSuccess()
    {
        var rnd = new Random();
        bool result = rnd.Next(0, 10) == 3;
        Console.WriteLine($"попытка:  {result}");
        return result;
    }
}