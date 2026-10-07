namespace apitest.Retries;

public class RetryHelper
{
    public delegate bool Operation();
    
    public static void Retry(Operation operation, int maxAttempts)
    {
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            Console.WriteLine($"Попытка : {attempt} из {maxAttempts} ");
            if (operation())
            {
                return;
            }
        }
        throw new Exception($"Пизда операции {operation} за {maxAttempts} попыток");
        
    }
    
    public static bool RetryUntilTrue(Operation operation, int maxAttempts)
    {
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            Console.WriteLine($"Попытка : {attempt} из {maxAttempts} ");
            if (operation())
            {
                return true;
            }
        }
        return false;
    }

    public static void RetryWithTimeOutsAndPauses(Operation operation, int timeoutsMs, int delaysMs)
    {
        var start = DateTime.Now;

        for (int attempt = 1;; attempt++)
        {
            Console.WriteLine($"{DateTime.Now}: Attempt # {attempt}");
            if (operation())
            {
                return;
            }

            if ((DateTime.Now - start).TotalMilliseconds >= timeoutsMs)
            {
                throw new Exception($"Операция не удалась за {timeoutsMs} мс. Попыток сделано {attempt}");
            }
            Thread.Sleep(delaysMs);
        }
    }
}
