using System;
using System.Collections.Generic;

namespace RomanNumeralsAPI.Models
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

            number = number.Trim().ToUpper();

            int result = 0;

            for (int i = 0; i < number.Length; i++)
            {
                if (i == 0)
                    result += CalculateRomanNumeralValue(number[i]);
                else
                    result += CalculateRomanNumeralValue(number[i], number[i - 1]);
            }

            return result;
        }

        public static IList<RomanValue> ExplainsValue(string romanNumeral)
        {
            IList<RomanValue> result = new List<RomanValue>();
            int sequence = 0;

            for (int i = 0; i < romanNumeral.Length; i++)
            {
                string currentChar = romanNumeral[i].ToString();

                RomanValue romanValue = new RomanValue() { Roman = currentChar, Value = Converts(currentChar) };

                if (i > 0 && result[result.Count - 1].Roman.Length == 1)
                {
                    string tempRomanNumeral = romanNumeral.Substring(i - 1, 2);

                    int lastAndCurrent = result[result.Count - 1].Value + romanValue.Value;
                    int valueParsed = Converts(tempRomanNumeral);

                    if (lastAndCurrent != valueParsed)
                    {
                        result[result.Count - 1].Value = valueParsed;
                        result[result.Count - 1].Roman = tempRomanNumeral;
                    }
                    else
                    {
                        romanValue.Sequence = ++sequence;
                        result.Add(romanValue);
                    }
                }
                else
                {
                    romanValue.Sequence = ++sequence;
                    result.Add(romanValue);
                }
            }

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
            string possibleValues = "IVXLCDM";

            string impossibleBeforeVX = "V";
            string impossibleBeforeLC = "IVL";
            string impossibleBeforeDM = "IVXD";

            string errorInvalidRomanNumeral = "Error. This is not a valid Roman Numeral.";

            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new Exception("None value sent.");

            value = value.Trim().ToUpper();

            int indexII = value.IndexOf("II");
            int indexIII = value.IndexOf("III");

            // Impossible Combinations
            int indexIVI = value.IndexOf("IVI");
            int indexIXI = value.IndexOf("IXI");
            int indexXCX = value.IndexOf("XCX");
            int indexCDC = value.IndexOf("CDC");
            int indexCMC = value.IndexOf("CMC");
            int indexIXX = value.IndexOf("IXX");
            int indexXCC = value.IndexOf("XCC");
            int indexCMM = value.IndexOf("CMM");
            int indexXLX = value.IndexOf("XLX");
            int indexXLC = value.IndexOf("XLC");
            int indexXLM = value.IndexOf("XLM");
            int indexXXXX = value.IndexOf("XXXX");
            int indexCCCC = value.IndexOf("CCCC");
            int indexMMMM = value.IndexOf("MMMM");

            if
            (
                (indexIII == -1 && indexII != -1 && indexII != value.Length - 2) ||
                (indexIII != -1 && indexIII != value.Length - 3) ||
                (indexIXI != -1) || (indexXCX != -1) || (indexIVI != -1) || (indexCDC != -1) || (indexCMC != -1) || (indexIXX != -1) ||
                (indexXCC != -1) || (indexCMM != -1) || (indexXLX != -1) || (indexXLC != -1) || (indexXLM != -1) ||
                (indexXXXX != - 1) || (indexCCCC != -1) || (indexMMMM != -1)
            )
            {
                throw new Exception(errorInvalidRomanNumeral);
            }

            for (int i = 0; i < value.Length; i++)
            {
                if (possibleValues.IndexOf(value[i]) == -1)
                    throw new Exception("Invalid Value. This is not a Roman Numeral.");

                if (i > 0)
                {
                    char currentChar = value[i];
                    char lastChar = value[i - 1];

                    switch (currentChar)
                    {
                        case 'V':
                        case 'X':
                            if (impossibleBeforeVX.IndexOf(lastChar) != -1)
                            {
                                throw new Exception(errorInvalidRomanNumeral);
                            }
                            break;
                        case 'L':
                        case 'C':
                            if (impossibleBeforeLC.IndexOf(lastChar) != -1)
                            {
                                throw new Exception(errorInvalidRomanNumeral);
                            }
                            break;
                        case 'D':
                        case 'M':
                            if (impossibleBeforeDM.IndexOf(lastChar) != -1)
                            {
                                throw new Exception(errorInvalidRomanNumeral);
                            }
                            break;
                    }
                }
            }
        }

        private static int CalculateRomanNumeralValue(char currentNumeral, char? lastNumeral = null)
        {
            int result = 0;

            switch (currentNumeral)
            {
                case 'I':
                    result = 1;
                    break;
                case 'V':
                    if (lastNumeral == 'I')
                        result = 3;
                    else
                        result = 5;
                    break;
                case 'X':
                    if (lastNumeral == 'I')
                        result = 8;
                    else
                        result = 10;
                    break;
                case 'L':
                    if (lastNumeral == 'X')
                        result = 30;
                    else
                        result = 50;
                    break;
                case 'C':
                    if (lastNumeral == 'X')
                        result = 80;
                    else
                        result = 100;
                    break;
                case 'D':
                    if (lastNumeral == 'C')
                        result = 300;
                    else
                        result = 500;
                    break;
                case 'M':
                    if (lastNumeral == 'C')
                        result = 800;
                    else
                        result = 1000;
                    break;
                default:
                    throw new Exception("Error. Invalid Numeral");
            }

            return result;
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
