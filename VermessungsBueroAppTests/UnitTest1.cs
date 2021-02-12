using NUnit.Framework;
using VermessungsBüroApp;

namespace VermessungsBueroAppTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //MainWindow mainwindow = new MainWindow();
            ZeileReinigen zeileReinigen = new ZeileReinigen();
            string expected = "      50200     98   400.000 1000.000            0 ";
            string actual = zeileReinigen.CleanLine("50200STKE 98   400.000   1000.000 \"   \"", false);
            Assert.IsTrue(string.Equals(expected, actual));
        }
    }
}
slim
