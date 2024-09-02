namespace FenXsDAL.Infrastructure.Logger;

public class LoggerConsole : ILogger
{
    public void SaveLog(string info) => Console.WriteLine($"{DateTime.Now} {info}");
}