using System;

namespace RomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tROMAN NUMERALS!");

            string option = string.Empty;

            do
            {
                DisplayMenu();

                option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.WriteLine("\n\tGOODBYE!");
                        break;
                    case "1":
                        try
                        {
                            int value = ReadDecimal();
                            PrintResult(value);
                        }
                        catch
                        {
                            Console.WriteLine("\n\tTHIS IS NOT A VALID NUMBER!");
                        }
                        break;
                    default:
                        Console.WriteLine("\n\tINVALID OPTION.");
                        break;

                }

            } while (option != "0");

            Console.Write("\t");
            Console.ReadKey();
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\n\tCHOOSE AN OPTION:\n");
            Console.WriteLine("\t1 - Parse from Decimal to Roman Numerals");
            Console.WriteLine("\t2 - Parse from Roman Numerals to Decimal");
            Console.WriteLine("\t0 - Exit");
            Console.Write("\n\tOPTION: ");
        }

        static int ReadDecimal()
        {
            string value = string.Empty;

            Console.Write("\n\tType a number to convert to Roman Numerals: ");

            value = Console.ReadLine();

            return int.Parse(value);
        }

        static void PrintResult(int number)
        {
            try
            {

                string result = RomanNumerals.Converts(number);
                Console.WriteLine($"\n\tVALUE: {number}\n\tRESULT: {result}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n\tVALUE: {number}\n\tERROR: {e.Message}");
            }
        }
    }
}
