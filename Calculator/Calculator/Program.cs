// See https://aka.ms/new-console-template for more information

Console.WriteLine("Welcome to the calculator");

Console.Write("Enter the first number: ");
int firstNumber = int.Parse(Console.ReadLine());

Console.Write("Enter the second number: ");
int secondNumber = int.Parse(Console.ReadLine());

int result = firstNumber * secondNumber;

Console.WriteLine("Result: " + result);
Console.ReadLine();
