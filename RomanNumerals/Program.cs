using System;

namespace RomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tROMAN NUMERALS!");

            string option;

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
                            string integer = ReadValue("Type an Integer to convert to Roman Numerals: ");
                            PrintResult(int.Parse(integer));
                        }
                        catch
                        {
                            Console.WriteLine("\n\tTHIS IS NOT A VALID NUMBER!");
                        }
                        break;
                    case "2":
                        string romanNumeral = ReadValue("Type a Roman Numeral to convert to Integer: ");
                        PrintResult(romanNumeral);
                        break;
                    case "9":
                        Console.Clear();
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
            Console.WriteLine("\t9 - Clear");
            Console.WriteLine("\t0 - Exit");
            Console.Write("\n\tOPTION: ");
        }

        static string ReadValue(string message)
        {
            Console.Write($"\n\t{message}");

            string value = Console.ReadLine();

            return value;
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

        static void PrintResult(string number)
        {
            try
            {

                int result = RomanNumerals.Converts(number);
                Console.WriteLine($"\n\tVALUE: {number}\n\tRESULT: {result}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n\tVALUE: {number}\n\tERROR: {e.Message}");
            }
        }
    }
}
