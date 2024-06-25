namespace Calculator;

class Program
{
    public static void Main(string[] args)
    {
        PrintWelcomeMessage();

        while (true)
        {
            string arithmeticOperator = GetOperator();
            if (arithmeticOperator == ".")
                break;

            int numberOfOperands = GetNumberOfOperands(arithmeticOperator);

            int[] operands = GetOperands(numberOfOperands);

            PerformCalculation(arithmeticOperator, operands);
        }
    }

    private static void PrintWelcomeMessage()
    {
        Console.WriteLine("Welcome to the calculator");
        Console.WriteLine("=========================");
        Console.WriteLine("To quit, type '.' at operator prompt.");
    }

    private static string GetOperator()
    {
        Console.Write("Please enter the operator: ");
        string arithmeticOperator = Console.ReadLine();
        return arithmeticOperator;
    }

    private static int GetNumberOfOperands(string arithmeticOperator)
    {
        int numberOfOperands = GetInteger("How many number do you want to " + arithmeticOperator + "?: ");
        return numberOfOperands;
    }

    private static int[] GetOperands(int numberOfOperands)
    {
        int[] operands = new int[numberOfOperands];

        for (int i = 0; i < operands.Length; i++)
        {
            operands[i] = GetInteger("Please enter number " + (i + 1) + ": ");
        }

        return operands;
    }

    private static void PerformCalculation(string arithmeticOperator, int[] operands)
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
                Console.WriteLine("Operator {0} is invalid.", arithmeticOperator);
        }

        Console.WriteLine("The answer is: " + result);
        Console.ReadLine();
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
}
