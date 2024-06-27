namespace Calculator;

class NumberCalculator
{
    private CalculatorLogger Logger { get; set; }
    
    public NumberCalculator(CalculatorLogger logger)
    {
        Logger = logger;
    }
    
    public void PerformNumberCalculation()
    {
        string arithmeticOperator = GetOperator();

        int numberOfOperands = GetNumberOfOperands(arithmeticOperator);

        int[] operands = GetOperands(numberOfOperands);

        Console.WriteLine($"The answer is: {CalculateValue(arithmeticOperator, operands)}");
        Console.ReadLine();
    }

    private string GetOperator()
    {
        string[] operators = new string[] { "+", "-", "*", "/" };
        string arithmeticOperator = "";

        do
        {
            Console.Write("Please enter the operator: ");
            arithmeticOperator = Console.ReadLine();
        } while (!operators.Contains(arithmeticOperator));
        
        return arithmeticOperator;
    }

    private int GetNumberOfOperands(string arithmeticOperator)
    {
        int numberOfOperands = GetInteger($"How many number do you want to {arithmeticOperator}?: ");
        return numberOfOperands;
    }

    private int[] GetOperands(int numberOfOperands)
    {
        int[] operands = new int[numberOfOperands];

        for (int i = 0; i < operands.Length; i++)
        {
            operands[i] = GetInteger($"Please enter number {i + 1}: ");
        }

        return operands;
    }

    private int CalculateValue(string arithmeticOperator, int[] operands)
    {
        int result = 0;

        foreach (int operand in operands)
        {
            // Set up result to be the first operand
            if (result == 0)
                result = operand;
            else if (arithmeticOperator == "+")
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

        LogCalculation(arithmeticOperator, operands, result);

        return result;
    }

    private int GetInteger(string message)
    {
        int number = 0;

        do
        {
            Console.Write(message);
        } while (!int.TryParse(Console.ReadLine(), out number));

        return number;
    }

    private void LogCalculation(string arithmeticOperator, int[] operands, int result)
    {
        string logMessage = $"Operator: {arithmeticOperator}; Operands:";

        foreach (int operand in operands)
        {
                logMessage += $" {operand}";
        }

        logMessage += $"; Result: {result}";
        
        Logger.WriteLog("NumberCalculator", logMessage);
    }
}