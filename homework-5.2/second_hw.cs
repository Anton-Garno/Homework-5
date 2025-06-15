using System;

class BaseProgram
{
    static void Main()
    {
        Console.WriteLine("Enter your number:");

        try
        {
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your number is: " + number);
        }
        catch
        {
            Console.WriteLine("Exception, not a number.");
        }
    }
}
