namespace apitest.Interfaces;

public class FileLogger:ILogger
{
    public void Log(string message)
    {
        File.AppendAllText("log.txt", message + Environment.NewLine);
        Console.WriteLine(message);
    }
}