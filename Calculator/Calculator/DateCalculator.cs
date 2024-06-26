namespace Calculator;

class DateCalculator
{
    public static void PerformDateCalculation()
    {
        DateTime inputDate = GetInputDate();

        int numberOfDaysToAdd = GetNumberOfDaysToAdd();

        Console.WriteLine($"The answer is: {CalculateDate(inputDate, numberOfDaysToAdd).ToShortDateString()}");
        Console.ReadLine();
    }

    private static DateTime GetInputDate()
    {
        DateTime inputDate;
        // while (true)
        // {
        //     Console.Write("Please enter a date: ");
        //     if (DateTime.TryParse(Console.ReadLine(), out inputDate))
        //         return inputDate;
        // }
        do
        {
            Console.Write("Please enter a date: ");
        } while (!DateTime.TryParse(Console.ReadLine(), out inputDate));
        return inputDate;
    }

    private static int GetNumberOfDaysToAdd()
    {
        int numberOfDaysToAdd = 0;
        // while (true)
        // {
        //     Console.Write("Please enter the number of days to add: ");
        //     if (int.TryParse(Console.ReadLine(), out numberOfDaysToAdd))
        //         return numberOfDaysToAdd;
        // }

        do
        {
            Console.Write("Please enter the number of days to add: ");
        } while (!int.TryParse(Console.ReadLine(), out numberOfDaysToAdd));

        return numberOfDaysToAdd;
    }

    private static DateTime CalculateDate(DateTime inputDate, int numberOfDaysToAdd)
    {
        return inputDate.AddDays(numberOfDaysToAdd);
    }
}