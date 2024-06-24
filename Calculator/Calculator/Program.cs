// See https://aka.ms/new-console-template for more information

Console.WriteLine("Welcome to the calculator");
Console.WriteLine("=========================");

Console.Write("Please enter the operator: ");
string arithmeticOperator = Console.ReadLine();

Console.Write("Enter the first number: ");
int firstNumber = int.Parse(Console.ReadLine());

Console.Write("Enter the second number: ");
int secondNumber = int.Parse(Console.ReadLine());

int result = 0;

// if (arithmeticOperator == "+")
//     result = firstNumber + secondNumber;
// else if (arithmeticOperator == "-")
//     result = firstNumber - secondNumber;
// else if (arithmeticOperator == "*")
//     result = firstNumber * secondNumber;
// else if (arithmeticOperator == "/")
//     result = firstNumber / secondNumber;
// else
//     Console.WriteLine("Operator {0} is invalid.", arithmeticOperator);

switch (arithmeticOperator)
{
    case "+":
        result = firstNumber + secondNumber;
        break;
    case "-":
        result = firstNumber - secondNumber;
        break;
    case "*":
        result = firstNumber * secondNumber;
        break;
    case "/":
        result = firstNumber / secondNumber;
        break;
    default:
        Console.WriteLine("Operator {0} is invalid.", arithmeticOperator);
        break;
}

Console.WriteLine("The answer is: " + result);
Console.ReadLine();
