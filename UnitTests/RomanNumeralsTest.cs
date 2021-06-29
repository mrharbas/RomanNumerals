using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumeralsAPI.Models;

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
                string result = RomanNumerals.Converts(value);

                throw new Exception("Test Failed.");
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
                string result = RomanNumerals.Converts(value);

                throw new Exception("Test Failed.");
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
            string result = RomanNumerals.Converts(value);

            switch (value)
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
            string result = RomanNumerals.Converts(value);

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
            string result = RomanNumerals.Converts(value);

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
            string result = RomanNumerals.Converts(value);

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

        [TestMethod]
        [DataRow("I")]
        [DataRow("III")]
        [DataRow("IV")]
        [DataRow("V")]
        [DataRow("VI")]
        [DataRow("VII")]
        [DataRow("IX")]
        public void ValidateParseToIntUnits(string value)
        {
            int result = RomanNumerals.Converts(value);

            switch (value)
            {
                case "I":
                    Assert.AreEqual(result, 1);
                    break;
                case "III":
                    Assert.AreEqual(result, 3);
                    break;
                case "IV":
                    Assert.AreEqual(result, 4);
                    break;
                case "V":
                    Assert.AreEqual(result, 5);
                    break;
                case "VI":
                    Assert.AreEqual(result, 6);
                    break;
                case "VII":
                    Assert.AreEqual(result, 7);
                    break;
                case "IX":
                    Assert.AreEqual(result, 9);
                    break;
            }
        }

        [TestMethod]
        [DataRow("X")]
        [DataRow("XI")]
        [DataRow("XV")]
        [DataRow("XVI")]
        [DataRow("XIX")]
        [DataRow("L")]
        [DataRow("LI")]
        [DataRow("LVI")]
        [DataRow("LXX")]
        [DataRow("LXXIII")]
        [DataRow("LXXXVIII")]
        [DataRow("XC")]
        [DataRow("XCVI")]
        public void ValidateParseToIntDecimals(string value)
        {
            int result = RomanNumerals.Converts(value);

            switch (value)
            {
                case "X":
                    Assert.AreEqual(result, 10);
                    break;
                case "XI":
                    Assert.AreEqual(result, 11);
                    break;
                case "XV":
                    Assert.AreEqual(result, 15);
                    break;
                case "XVI":
                    Assert.AreEqual(result, 16);
                    break;
                case "XIX":
                    Assert.AreEqual(result, 19);
                    break;
                case "L":
                    Assert.AreEqual(result, 50);
                    break;
                case "LI":
                    Assert.AreEqual(result, 51);
                    break;
                case "LVI":
                    Assert.AreEqual(result, 56);
                    break;
                case "LXX":
                    Assert.AreEqual(result, 70);
                    break;
                case "LXXIII":
                    Assert.AreEqual(result, 73);
                    break;
                case "LXXXVIII":
                    Assert.AreEqual(result, 88);
                    break;
                case "XC":
                    Assert.AreEqual(result, 90);
                    break;
                case "XCVI":
                    Assert.AreEqual(result, 96);
                    break;
            }
        }

        [TestMethod]
        [DataRow("C")]
        [DataRow("CX")]
        [DataRow("D")]
        [DataRow("DV")]
        [DataRow("DL")]
        [DataRow("CMLXXXVIII")]
        [DataRow("CMXCIX")]
        public void ValidateParseToIntHundreds(string value)
        {
            int result = RomanNumerals.Converts(value);

            switch (value)
            {
                case "C":
                    Assert.AreEqual(result, 100);
                    break;
                case "CX":
                    Assert.AreEqual(result, 110);
                    break;
                case "D":
                    Assert.AreEqual(result, 500);
                    break;
                case "DV":
                    Assert.AreEqual(result, 505);
                    break;
                case "DL":
                    Assert.AreEqual(result, 550);
                    break;
                case "CMLXXXVIII":
                    Assert.AreEqual(result, 988);
                    break;
                case "CMXCIX":
                    Assert.AreEqual(result, 999);
                    break;
            }
        }

        [TestMethod]
        [DataRow("M")]
        [DataRow("MI")]
        [DataRow("MX")]
        [DataRow("MC")]
        [DataRow("MCX")]
        [DataRow("MCXI")]
        [DataRow("MMCMXCIX")]
        [DataRow("MMMDLXXXVIII")]
        public void ValidateParseToIntThousands(string value)
        {
            int result = RomanNumerals.Converts(value);

            switch (value)
            {
                case "M":
                    Assert.AreEqual(result, 1000);
                    break;
                case "MI":
                    Assert.AreEqual(result, 1001);
                    break;
                case "MX":
                    Assert.AreEqual(result, 1010);
                    break;
                case "MC":
                    Assert.AreEqual(result, 1100);
                    break;
                case "MCX":
                    Assert.AreEqual(result, 1110);
                    break;
                case "MCXI":
                    Assert.AreEqual(result, 1111);
                    break;
                case "MMCMXCIX":
                    Assert.AreEqual(result, 2999);
                    break;
                case "MMMDLXXXVIII":
                    Assert.AreEqual(result, 3588);
                    break;
            }
        }

        [TestMethod]
        [DataRow("MXA")]
        [DataRow("ZZZ")]
        [DataRow("bçqc")]
        public void ValidateParseToIntInvalidValue(string value)
        {
            try
            {
                int result = RomanNumerals.Converts(value);

                throw new Exception("Test Failed.");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Invalid Value. This is not a Roman Numeral.");
            }
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("   ")]
        public void ValidateParseToIntEmptyValue(string value)
        {
            try
            {
                int result = RomanNumerals.Converts(value);

                throw new Exception("Test Failed.");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "None value sent.");
            }
        }

        [TestMethod]
        [DataRow("IVI")]
        [DataRow("IXI")]
        [DataRow("XCX")]
        [DataRow("CDC")]
        [DataRow("CMC")]
        [DataRow("IIVII")]
        [DataRow("IIII")]
        [DataRow("IIIV")]
        [DataRow("IIV")]
        [DataRow("IIX")]
        [DataRow("IIM")]
        [DataRow("VV")]
        [DataRow("VX")]
        [DataRow("IL")]
        [DataRow("VL")]
        [DataRow("IC")]
        [DataRow("VC")]
        [DataRow("ID")]
        [DataRow("VD")]
        [DataRow("XD")]
        [DataRow("DD")]
        [DataRow("IM")]
        [DataRow("VM")]
        [DataRow("XM")]
        [DataRow("DM")]
        [DataRow("IXX")]
        [DataRow("XCC")]
        [DataRow("CMM")]
        [DataRow("XLX")]
        [DataRow("XLC")]
        [DataRow("XLM")]
        public void ValidateInvalidRomanNumeralFormat(string value)
        {
            try
            {
                int result = RomanNumerals.Converts(value);
                
                throw new Exception("Test Failed.");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Error. This is not a valid Roman Numeral.");
            }
        }

        [TestMethod]
        [DataRow("MMCMXCIX")]
        public void ValidateExplainedValue(string value)
        {
            var result = RomanNumerals.ExplainsValue(value);

            Assert.AreEqual(result.Count, 5);
            
            Assert.AreEqual(result[0].Roman, "M");
            Assert.AreEqual(result[0].Value, 1000);
            Assert.AreEqual(result[0].Sequence, 1);

            Assert.AreEqual(result[1].Roman, "M");
            Assert.AreEqual(result[1].Value, 1000);
            Assert.AreEqual(result[1].Sequence, 2);

            Assert.AreEqual(result[2].Roman, "CM");
            Assert.AreEqual(result[2].Value, 900);
            Assert.AreEqual(result[2].Sequence, 3);

            Assert.AreEqual(result[3].Roman, "XC");
            Assert.AreEqual(result[3].Value, 90);
            Assert.AreEqual(result[3].Sequence, 4);
            
            Assert.AreEqual(result[4].Roman, "IX");
            Assert.AreEqual(result[4].Value, 9);
            Assert.AreEqual(result[4].Sequence, 5);
        }
    }
}
