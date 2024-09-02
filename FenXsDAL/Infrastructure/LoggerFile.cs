namespace FenXsDAL.Infrastructure.Logger;

public class LoggerFile : ILogger
{
    public async void SaveLog(string info)
    {
        using (StreamWriter loggerFile = new(AppContext.BaseDirectory + "/FenXs Logs.txt", true))
        {
            await loggerFile.WriteLineAsync($"{DateTime.Now} {info}");
            loggerFile.Close();
        }
    }
}