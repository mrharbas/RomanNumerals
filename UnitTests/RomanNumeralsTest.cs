using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals;

namespace UnitTests
{
    [TestClass]
    public class RomanNumeralsTest
    {
        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void ValidateZeroOrNegativeValue(int value)
        {
            try
            {
                string result = RomanNumerals.RomanNumerals.Converts(value);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Invalid Value. The number to be converted cannot be equal to or less than zero.");
            }
        }

        [TestMethod]
        [DataRow(4000)]
        public void ValidateTooBigValue(int value)
        {
            try
            {
                string result = RomanNumerals.RomanNumerals.Converts(value);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "This value cannot be parsed to Roman Numerals.");
            }
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(9)]
        public void ValidateUnitParse(int value)
        {
            string result = RomanNumerals.RomanNumerals.Converts(value);

            switch(value)
            {
                case 1:
                    Assert.AreEqual(result, "I");
                    break;
                case 3:
                    Assert.AreEqual(result, "III");
                    break;
                case 5:
                    Assert.AreEqual(result, "V");
                    break;
                case 9:
                    Assert.AreEqual(result, "IX");
                    break;
            }
        }

        [TestMethod]
        [DataRow(10)]
        [DataRow(11)]
        [DataRow(30)]
        [DataRow(45)]
        [DataRow(50)]
        [DataRow(90)]
        [DataRow(99)]
        public void ValidateDecimalParse(int value)
        {
            string result = RomanNumerals.RomanNumerals.Converts(value);

            switch (value)
            {
                case 10:
                    Assert.AreEqual(result, "X");
                    break;
                case 11:
                    Assert.AreEqual(result, "XI");
                    break;
                case 30:
                    Assert.AreEqual(result, "XXX");
                    break;
                case 45:
                    Assert.AreEqual(result, "XLV");
                    break;
                case 50:
                    Assert.AreEqual(result, "L");
                    break;
                case 90:
                    Assert.AreEqual(result, "XC");
                    break;
                case 99:
                    Assert.AreEqual(result, "XCIX");
                    break;
            }
        }

        [TestMethod]
        [DataRow(100)]
        [DataRow(111)]
        [DataRow(300)]
        [DataRow(457)]
        [DataRow(500)]
        [DataRow(900)]
        [DataRow(992)]
        public void ValidateHundredParse(int value)
        {
            string result = RomanNumerals.RomanNumerals.Converts(value);

            switch (value)
            {
                case 100:
                    Assert.AreEqual(result, "C");
                    break;
                case 111:
                    Assert.AreEqual(result, "CXI");
                    break;
                case 300:
                    Assert.AreEqual(result, "CCC");
                    break;
                case 457:
                    Assert.AreEqual(result, "CDLVII");
                    break;
                case 500:
                    Assert.AreEqual(result, "D");
                    break;
                case 900:
                    Assert.AreEqual(result, "CM");
                    break;
                case 992:
                    Assert.AreEqual(result, "CMXCII");
                    break;
            }
        }

        [TestMethod]
        [DataRow(1100)]
        [DataRow(2111)]
        [DataRow(3300)]
        [DataRow(1457)]
        [DataRow(2500)]
        [DataRow(3900)]
        [DataRow(1992)]
        public void ValidateThousandParse(int value)
        {
            string result = RomanNumerals.RomanNumerals.Converts(value);

            switch (value)
            {
                case 1100:
                    Assert.AreEqual(result, "MC");
                    break;
                case 2111:
                    Assert.AreEqual(result, "MMCXI");
                    break;
                case 3300:
                    Assert.AreEqual(result, "MMMCCC");
                    break;
                case 1457:
                    Assert.AreEqual(result, "MCDLVII");
                    break;
                case 2500:
                    Assert.AreEqual(result, "MMD");
                    break;
                case 3900:
                    Assert.AreEqual(result, "MMMCM");
                    break;
                case 1992:
                    Assert.AreEqual(result, "MCMXCII");
                    break;
            }
        }
    }
}
