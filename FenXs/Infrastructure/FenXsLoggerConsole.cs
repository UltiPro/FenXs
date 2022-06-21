namespace Infrastructure.FenXsLogger;

public class FenXsLoggerConsole : IFenXsLogger
{
    public void SaveLog(string info)
    {
        DateTime now = DateTime.Now;
        Console.WriteLine(now + " " + info);
    }
}