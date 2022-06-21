namespace DAL.FenXsLoggerConsole;

public class FenXsLoggerConsole : DAL.IFenXsLogger.IFenXsLogger
{
    DateTime now;
    public void SaveLog(string info)
    {
        now = DateTime.Today;
        Console.WriteLine(now+" "+info);
    }
}