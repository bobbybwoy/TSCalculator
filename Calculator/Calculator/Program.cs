namespace Calculator;

class Program
{
    private const int NumberCalculator = 1;
    private const int DateCalculator = 2;
    private const int Exit = 3;

    public static void Main(string[] args)
    {
        PrintWelcomeMessage();
        NumberCalculator numberCalculator = new NumberCalculator();
        DateCalculator dateCalculator = new DateCalculator();

        while (true)
        {
            int calculatorMode = GetCalculatorMode();
            if (calculatorMode == NumberCalculator)
                // I also used Rider to refactor the functionality into
                // separate classes, which is why the namespace is the
                // way it is...
                numberCalculator.PerformNumberCalculation();
            else if (calculatorMode == DateCalculator)
                dateCalculator.PerformDateCalculation();
            else if (calculatorMode == Exit)
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
                Console.WriteLine("Option invalid");
        }
    }

    private static void PrintWelcomeMessage()
    {
        Console.WriteLine("Welcome to the calculator");
        Console.WriteLine("=========================");
    }

    private static int GetCalculatorMode()
    {
        int calculatorMode = 0;
        Console.WriteLine("Choose calculator mode:");
        Console.WriteLine("\t1) Numbers");
        Console.WriteLine("\t2) Dates");
        Console.WriteLine("\t3) Exit");
        Console.Write("\nOption: ");
        int.TryParse(Console.ReadLine(), out calculatorMode);
        return calculatorMode;
    }
}