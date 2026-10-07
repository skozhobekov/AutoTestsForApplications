using Polly;
using Polly.Timeout;

namespace apitest.Retries;

public class RetryWithPollyHelper
{
    public delegate bool Operation();

    public static void RetryWithPolly(Operation operation, int timeoutMs, int delayMs)
    {
        //правила для повторных попыток
        var retryPolicy = Policy
            .HandleResult<bool>(r => !r)
            .WaitAndRetry(
                retryCount: int.MaxValue,
                sleepDurationProvider: _ => TimeSpan.FromSeconds(delayMs),
                onRetry: (outcome, timespan, attempt, context) =>
                {
                    Console.WriteLine($"Retrying with {timespan.TotalSeconds} seconds...");
                });
        //правила по времени
        var timeoutPolicy = Policy.Timeout(
            TimeSpan.FromSeconds(timeoutMs),
            TimeoutStrategy.Optimistic);

        timeoutPolicy.Wrap(retryPolicy).Execute(() => {return operation();
    });

    timeoutPolicy.Wrap(timeoutPolicy);
    }   
}