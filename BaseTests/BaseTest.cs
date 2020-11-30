using NUnit.Framework;
using SeleniumNet5.Selenium;

namespace SeleniumNet5.BaseTests
{
    [TestFixture]
    public class BaseTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            SeleniumHandler.Init();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            SeleniumHandler.Close();
        }

        [SetUp]
        public void TestInitialize()
        {
            SeleniumHandler.LogTest(TestContext.CurrentContext.Test.Name);

        }
    }
}