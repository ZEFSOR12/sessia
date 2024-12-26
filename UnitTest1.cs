using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary2;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        public static int ResultUnit1 { get; set; }
        [TestMethod]
        public void TestDateNach(string Date)
        {
            string DateTest = Date;
            bool expected = false;
            Class1 g = new Class1();
            bool result = g.Test1(DateTest);
            try
            {
                Assert.AreEqual(expected, result);
                ResultUnit1 = 1;
            }
            catch (Exception ex)
            { ResultUnit1 = 0; }
        }
        public static int ResultUnit2 { get; set; }
        [TestMethod]
        public void TestDateOkonch(string Date)
        {
            string DateTest = Date;
            bool expected = false;
            Class1 g = new Class1();
            bool result = g.Test1(DateTest);
            try
            {
                Assert.AreEqual(expected, result);
                ResultUnit2 = 1;
            }
            catch (Exception ex)
            { ResultUnit2 = 0; }
        }
    }
}
