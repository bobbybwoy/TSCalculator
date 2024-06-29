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

        List<int> operands = GetOperands(arithmeticOperator);

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
    
    private List<int> GetOperands(string arithmeticOperator)
    {
        List<int> operands = new List<int>();

        Console.WriteLine($"Please enter the numbers to {arithmeticOperator}.");
        while (true)
        {
            int? operand = GetInteger("Please enter the next number: ");
            if (!operand.HasValue) break;
            
            operands.Add(operand.Value);
        }

        return operands;
    }

    private int CalculateValue(string arithmeticOperator, List<int> operands)
    {
        int result = 0;

        if (arithmeticOperator == "+")
            result = operands.Sum();
        else if (arithmeticOperator == "-")
        {
            result = operands.First();
            result = operands
                .Skip(1)
                .Aggregate(result,
                    (aggregate, next) => aggregate -= next,
                    aggregate => aggregate);
        }
        else if (arithmeticOperator == "*")
        {
            result = operands.First();
            result = operands
                .Skip(1)
                .Aggregate(result,
                    (aggregate, next) => aggregate *= next,
                    aggregate => aggregate);
        }
        else if (arithmeticOperator == "/")
        {
            result = operands.First();
            result = operands
                .Skip(1)
                .Aggregate(result,
                    (aggregate, next) => aggregate /= next,
                    aggregate => aggregate);
        }                

        LogCalculation(arithmeticOperator, operands, result);

        return result;
    }

    private int? GetInteger(string message)
    {
        int number = 0;
        string aNumber = "";

        do
        {
            Console.Write(message);
            aNumber = Console.ReadLine();
            
            if (aNumber == "") return null;
            
        } while (!int.TryParse(aNumber, out number));

        return number;
    }

    private void LogCalculation(string arithmeticOperator, List<int> operands, int result)
    {
        string logMessage = $"Operator: {arithmeticOperator}; Operands: [";

        operands.ForEach(operand => logMessage += $" {operand}");

        logMessage += $" ]; Result: {result}";
        
        Logger.WriteLog("NumberCalculator", logMessage);
    }
}