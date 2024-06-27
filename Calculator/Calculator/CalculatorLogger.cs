namespace Calculator;

// Source for this code: https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-open-and-append-to-a-log-file
public class CalculatorLogger
{
    private readonly string _logFilePath = "../../../../../Log.txt";
    public CalculatorLogger()
    {
        ClearLog();
    }
    
    // This method will create a new file.
    private void ClearLog()
    {
        File.Delete(_logFilePath);
    }

    // This method will append any messages passed to the log file.
    public void WriteLog(string calculatorMode, string logMessage)
    {
        using (StreamWriter writer = File.AppendText(_logFilePath))
        {
            writer
                .WriteLine($"{calculatorMode} - {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}: {logMessage}");
        }
    }
}