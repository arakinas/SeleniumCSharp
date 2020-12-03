using NUnit.Framework;
using SeleniumNet5.RestSharp;

namespace SeleniumNet5.BaseTests
{
    [TestFixture]
    public class BaseRestTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
           RestSharpHandler.Init();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
        }

        [SetUp]
        public void TestInitialize()
        {
            RestSharpHandler.LogTest(TestContext.CurrentContext.Test.Name);
        }
    }
}