﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using имя проекта;

namespace WpfApp1
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

        //class1
     public static bool CheckForNil(string pass, string email)
    {
        bool isNull = true;
        if (!string.IsNullOrEmpty(pass) || !string.IsNullOrEmpty(email))
        {
            isNull = false;
        }
        return isNull;
    }

//tescunit

        public void Test1()
{
    [Fact]
    public void TestForNull()
    {
        bool result = Class1.CheckForNil("123", null);
        Assert.False(result);
    }

    [Fact]
    public void TestForeEmpty()
    {
        bool result = Class1.CheckForNil("123", "");
        Assert.False(result);
    }
    }
}
