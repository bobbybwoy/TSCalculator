namespace Calculator;

class DateCalculator
{
    public void PerformDateCalculation()
    {
        DateTime inputDate = GetInputDate();

        int numberOfDaysToAdd = GetNumberOfDaysToAdd();

        Console.WriteLine($"The answer is: {CalculateDate(inputDate, numberOfDaysToAdd).ToShortDateString()}");
        Console.ReadLine();
    }

    private DateTime GetInputDate()
    {
        DateTime inputDate;

        do
        {
            Console.Write("Please enter a date: ");
        } while (!DateTime.TryParse(Console.ReadLine(), out inputDate));
        
        return inputDate;
    }

    private int GetNumberOfDaysToAdd()
    {
        int numberOfDaysToAdd = 0;

        do
        {
            Console.Write("Please enter the number of days to add: ");
        } while (!int.TryParse(Console.ReadLine(), out numberOfDaysToAdd));

        return numberOfDaysToAdd;
    }

    private DateTime CalculateDate(DateTime inputDate, int numberOfDaysToAdd)
    {
        return inputDate.AddDays(numberOfDaysToAdd);
    }
}