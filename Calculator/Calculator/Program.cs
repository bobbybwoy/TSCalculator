namespace Calculator;

class Program
{
    public static void Main(string[] args)
    {
        CalculatorLogger logger = new CalculatorLogger();
        
        NumberCalculator numberCalculator = new NumberCalculator(logger);
        DateCalculator dateCalculator = new DateCalculator(logger);
        
        PrintWelcomeMessage();

        while (true)
        {
            CalculatorMode calculatorMode = GetCalculatorMode();

            if (calculatorMode == CalculatorMode.Exit)
                break;

            switch (calculatorMode)
            {
                case CalculatorMode.NumberCalculator:
                    numberCalculator.PerformNumberCalculation();
                    break;
                case CalculatorMode.DateCalculator:
                    dateCalculator.PerformDateCalculation();
                    break;
                default:
                    Console.WriteLine("Option invalid");
                    break;
            }
        }
    }

    private static void PrintWelcomeMessage()
    {
        Console.WriteLine("Welcome to the calculator");
        Console.WriteLine("=========================");
    }

    private static CalculatorMode GetCalculatorMode()
    {
        CalculatorMode calculatorMode;
        
        Console.WriteLine("Choose calculator mode:");
        Console.WriteLine("\t1) Numbers");
        Console.WriteLine("\t2) Dates");
        Console.WriteLine("\t3) Exit");
        Console.Write("\nOption: ");
        Enum.TryParse(Console.ReadLine(), out calculatorMode);
        
        return calculatorMode;
    }
}

enum CalculatorMode
{
    NumberCalculator = 1,
    DateCalculator = 2,
    Exit = 3
}
