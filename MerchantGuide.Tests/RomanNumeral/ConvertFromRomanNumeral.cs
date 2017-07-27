using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MerchantGuide.Tests.RomanNumeral
{
    [TestClass]
    public class ConvertFromRomanNumeral
    {
        [TestMethod]
        public void MustConvert_SingleDigitNumbers()
        {
            MustConvert("I", 1);
            MustConvert("V", 5);
            MustConvert("X", 10);
            MustConvert("L", 50);
            MustConvert("C", 100);
            MustConvert("D", 500);
            MustConvert("M", 1000);
        }

        [TestMethod]
        public void MustConvert_XX_Into_20()
        {
            MustConvert("XX", 20);
        }

        [TestMethod]
        public void MustConvert_XIX_Into_19()
        {
            MustConvert("XIX", 19);
        }

        [TestMethod]
        public void MustConvert_MMMCMXCIX_Into_3999()
        {
            MustConvert("MMMCMXCIX", 3999);
        }

        private void MustConvert(string value, int expected)
        {
            int actual = MerchantGuide.RomanNumeral.Converter.ConvertFromRomanNumeral(value);
            Assert.AreEqual(expected, actual);
        }
    }
}
