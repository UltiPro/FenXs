namespace Infrastructure.FenXsLogger;

public class FenXsLoggerFile : IFenXsLogger
{
    public async void SaveLog(string info)
    {
        DateTime now = DateTime.Now;
        StreamWriter file = new("Infrastructure/LogsDB.txt", true);
        await file.WriteLineAsync(now + " " + info);
        file.Close();
    }
}