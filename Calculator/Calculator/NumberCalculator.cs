namespace Calculator;

class NumberCalculator
{
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
        Console.Write("Please enter the operator: ");
        string arithmeticOperator = Console.ReadLine();
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

    private int GetInteger(string message)
    {
        int number = 0;

        do
        {
            Console.Write(message);
        } while (!int.TryParse(Console.ReadLine(), out number));

        return number;
    }
}