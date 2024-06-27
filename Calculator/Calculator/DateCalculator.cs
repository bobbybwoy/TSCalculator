namespace Calculator;

class DateCalculator
{
    public CalculatorLogger Logger { get; set; }
    
    public DateCalculator(CalculatorLogger logger)
    {
        Logger = logger;
    }
    
    public void PerformDateCalculation()
    {
        DateTime inputDate = GetInputDate();

        int numberOfDaysToAdd = GetNumberOfDaysToAdd();

        Console.WriteLine($"The answer is: {CalculateDate(inputDate, numberOfDaysToAdd).ToShortDateString()}");
        Console.ReadLine();
    }

    private DateTime GetInputDate()
    {
        DateTime inputDate;

        do
        {
            Console.Write("Please enter a date: ");
        } while (!DateTime.TryParse(Console.ReadLine(), out inputDate));
        
        return inputDate;
    }

    private int GetNumberOfDaysToAdd()
    {
        int numberOfDaysToAdd = 0;

        do
        {
            Console.Write("Please enter the number of days to add: ");
        } while (!int.TryParse(Console.ReadLine(), out numberOfDaysToAdd));

        return numberOfDaysToAdd;
    }

    private DateTime CalculateDate(DateTime inputDate, int numberOfDaysToAdd)
    {
        DateTime resultantDate =  inputDate.AddDays(numberOfDaysToAdd);

        LogCalculation(inputDate, numberOfDaysToAdd, resultantDate);
        
        return resultantDate;
    }

    private void LogCalculation(DateTime inputDate, int numberOfDaysToAdd, DateTime resultantDate)
    {
        string logMessage =
            $"Input Date: {inputDate.ToShortDateString()}; Number of days to add: {numberOfDaysToAdd.ToString()}" +
            $"; Resultant Date: {resultantDate.ToShortDateString()}";
        
        Logger.WriteLog("Date Calculator", logMessage);
    }
}