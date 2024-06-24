// See https://aka.ms/new-console-template for more information

Console.WriteLine("Welcome to the calculator");
Console.WriteLine("=========================");

Console.Write("Please enter the operator: ");
string arithmeticOperator = Console.ReadLine();

Console.Write("How many numbers do you want to {0}?: ", arithmeticOperator);
int numOfOperands = int.Parse(Console.ReadLine());

int[] operands = new int[numOfOperands];

for (int i = 0; i < operands.Length; i++)
{
    Console.Write("Please enter number {0}: ", (i + 1));
    operands[i] = int.Parse(Console.ReadLine());
}

int result = 0;

foreach (int operand in operands)
{
    // Set up result initially
    if (result == 0)
    {
        result = operand;
        continue;
    }

    switch (arithmeticOperator)
    {
        case "+":
            result += operand;
            break;
        case "-":
            result -= operand;
            break;
        case "*":
            result *= operand;
            break;
        case "/":
            result /= operand;
            break;
        default:
            Console.WriteLine("Operator {0} is invalid.", arithmeticOperator);
            break;
    }
}

Console.WriteLine("The answer is: " + result);
Console.ReadLine();
