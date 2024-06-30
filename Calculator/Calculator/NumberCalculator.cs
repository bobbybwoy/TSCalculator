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
        try
        {
            string arithmeticOperator = GetOperator();

            List<int> operands = GetOperands(arithmeticOperator);

            Console.WriteLine($"The answer is: {CalculateValue(arithmeticOperator, operands)}");
        }
        catch (ArithmeticOperatorNotValidException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.ReadLine();
            Console.Clear();
        }
    }

    private string GetOperator()
    {
        string[] operators = new string[] { "+", "-", "*", "/" };
        string arithmeticOperator = "";

        Console.Write("Please enter the operator: ");
        arithmeticOperator = Console.ReadLine();
        if (!operators.Contains(arithmeticOperator))
            throw new ArithmeticOperatorNotValidException($"Operator \'{arithmeticOperator}\' is not valid");
        
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

        switch (arithmeticOperator)
        {
            case "+":
                result = operands.Sum();
                break;
            case "-":
                result = operands.First();
                result = operands
                    .Skip(1)
                    .Aggregate(result,
                        (aggregate, next) => aggregate -= next,
                        aggregate => aggregate);
                break;
            case "*":
                result = operands.First();
                result = operands
                    .Skip(1)
                    .Aggregate(result,
                        (aggregate, next) => aggregate *= next,
                        aggregate => aggregate);
                break;
            case "/":
                result = operands.First();
                result = operands
                    .Skip(1)
                    .Aggregate(result,
                        (aggregate, next) => aggregate /= next,
                        aggregate => aggregate);
                break;
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

public class ArithmeticOperatorNotValidException : Exception
{
    public ArithmeticOperatorNotValidException() : base() {}

    public ArithmeticOperatorNotValidException(string message) : base(message){}
    public ArithmeticOperatorNotValidException(string message, Exception inner) : base(message, inner) {}
}
