namespace Calculator;

class Program
{
    private const int NumberCalculator = 1;
    private const int DateCalculator = 2;
    public static void Main(string[] args)
    {
        PrintWelcomeMessage();

        while (true)
        {
            int calculatorMode = GetCalculatorMode();
            if (calculatorMode == NumberCalculator)
                PerformNumberCalculation();
            else if (calculatorMode == DateCalculator)
                PerformDateCalculation();
            else
                break;
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
        int.TryParse(Console.ReadLine(), out calculatorMode);
        return calculatorMode;
    }

    private static void PerformNumberCalculation()
    {
        string arithmeticOperator = GetOperator();

        int numberOfOperands = GetNumberOfOperands(arithmeticOperator);

        int[] operands = GetOperands(numberOfOperands);

        Console.WriteLine($"The answer is: {CalculateValue(arithmeticOperator, operands)}");
        Console.ReadLine();
    }

    private static void PerformDateCalculation()
    {
        DateTime inputDate = GetInputDate();

        int numberOfDaysToAdd = GetNumberOfDaysToAdd();

        Console.WriteLine($"The answer is: {CalculateDate(inputDate, numberOfDaysToAdd).ToShortDateString()}");
        Console.ReadLine();
    }

    private static string GetOperator()
    {
        Console.Write("Please enter the operator: ");
        string arithmeticOperator = Console.ReadLine();
        return arithmeticOperator;
    }

    private static int GetNumberOfOperands(string arithmeticOperator)
    {
        int numberOfOperands = GetInteger($"How many number do you want to {arithmeticOperator}?: ");
        return numberOfOperands;
    }

    private static int[] GetOperands(int numberOfOperands)
    {
        int[] operands = new int[numberOfOperands];

        for (int i = 0; i < operands.Length; i++)
        {
            operands[i] = GetInteger($"Please enter number {i + 1}: ");
        }

        return operands;
    }

    private static int CalculateValue(string arithmeticOperator, int[] operands)
    {
        int result = 0;

        foreach (int operand in operands)
        {
            // Set up result to be the first operand
            if (result == 0)
            {
                result = operand;
                continue;
            }

            if (arithmeticOperator == "+")
                result += operand;
            else if (arithmeticOperator == "-")
                result -= operand;
            else if (arithmeticOperator == "*")
                result *= operand;
            else if (arithmeticOperator == "/")
                result /= operand;
            else
                Console.WriteLine($"Operator {arithmeticOperator} is invalid.");
        }

        return result;
    }

    private static int GetInteger(string message)
    {
        int number = 0;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out number))
                return number;
        }
    }

    private static DateTime GetInputDate()
    {
        DateTime inputDate;
        while (true)
        {
            Console.Write("Please enter a date: ");
            if (DateTime.TryParse(Console.ReadLine(), out inputDate))
                return inputDate;
        }
    }

    private static int GetNumberOfDaysToAdd()
    {
        int numberOfDaysToAdd = 0;
        Console.Write("Please enter the number of days to add: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out numberOfDaysToAdd))
                return numberOfDaysToAdd;
        }
    }

    private static DateTime CalculateDate(DateTime inputDate, int numberOfDaysToAdd)
    {

        return inputDate.AddDays(numberOfDaysToAdd);
    }
}
