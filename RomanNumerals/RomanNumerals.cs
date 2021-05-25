using System;

namespace RomanNumerals
{
    public static class RomanNumerals
    {
        public static string Converts(int number)
        {
            ValidateValue(number);

            string result = string.Empty;

            int thousands;
            int hundreds;
            int decimals;

            int currentValue = number;

            thousands = currentValue / 1000;

            if (thousands > 0)
            {
                result += CalculateThousands(thousands);
                currentValue -= thousands * 1000;
            }

            hundreds = currentValue / 100;

            if (hundreds > 0)
            {
                result += CalculateHundreds(hundreds);
                currentValue -= hundreds * 100;
            }

            decimals = currentValue / 10;

            if (decimals > 0)
            {
                result += CalculateDecimals(decimals);
                currentValue -= decimals * 10;
            }

            if (currentValue > 0)
            {
                result += CalculateUnits(currentValue);
            }

            return result;
        }

        public static int Converts(string number)
        {
            ValidateValue(number);

            int result = 0;

            return result;
        }

        private static void ValidateValue(int value)
        {
            if (value <= 0)
            {
                throw new Exception("Invalid Value. The number to be converted cannot be equal to or less than zero.");
            }
            else if (value >= 4000)
            {
                throw new Exception("This value cannot be parsed to Roman Numerals.");
            }
        }

        private static void ValidateValue(string value)
        {
            string[] possibleValues = { "I", "V", "X", "L", "C", "D", "M" };

            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new Exception("None value sent.");

            for (int i = 0; i < value.Length; i++)
            {
                if (!possibleValues.ToString().Contains(value.ToUpper()[i]))
                    throw new Exception("Invalid Value. This is not a Roman Numeral.");
            }
        }

        private static string CalculateThousands(int value)
        {
            switch (value)
            {
                case 1:
                    return "M";
                case 2:
                    return "MM";
                case 3:
                    return "MMM";
                default:
                    throw new Exception("Fail to calculate the thousands count.");
            }
        }

        private static string CalculateHundreds(int value)
        {
            switch (value)
            {
                case 1:
                    return "C";
                case 2:
                    return "CC";
                case 3:
                    return "CCC";
                case 4:
                    return "CD";
                case 5:
                    return "D";
                case 6:
                    return "DC";
                case 7:
                    return "DCC";
                case 8:
                    return "DCCC";
                case 9:
                    return "CM";
                default:
                    throw new Exception("Fail to calculate the hundreds count.");
            }
        }

        private static string CalculateDecimals(int value)
        {
            switch (value)
            {
                case 1:
                    return "X";
                case 2:
                    return "XX";
                case 3:
                    return "XXX";
                case 4:
                    return "XL";
                case 5:
                    return "L";
                case 6:
                    return "LX";
                case 7:
                    return "LXX";
                case 8:
                    return "LXXX";
                case 9:
                    return "XC";
                default:
                    throw new Exception("Fail to calculate the decimals count.");
            }
        }

        private static string CalculateUnits(int value)
        {
            switch (value)
            {
                case 1:
                    return "I";
                case 2:
                    return "II";
                case 3:
                    return "III";
                case 4:
                    return "IV";
                case 5:
                    return "V";
                case 6:
                    return "VI";
                case 7:
                    return "VII";
                case 8:
                    return "VIII";
                case 9:
                    return "IX";
                default:
                    throw new Exception("Fail to calculate the units count.");
            }
        }
    }
}
