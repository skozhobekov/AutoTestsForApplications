using Microsoft.Extensions.Logging;

namespace apitest.Interfaces;

public class LoggerService
{
    public void WriteLog(ILogger logger, string message)
    { 
         logger.Log(message);
        
    }
}