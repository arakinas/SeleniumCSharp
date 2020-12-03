using NUnit.Framework;
using SeleniumNet5.Selenium;
using SeleniumNet5.BaseTests;
using SeleniumNet5.Selenium.Pages.AutomationPractice;

namespace SeleniumNet5.Tests.UI
{
    [TestFixture]
    public class ExampleUITests : BaseWebTest
    {

        [Test]
        public void SearchAutomationPracticeForClothesWithNoResults()
        {
            Index automationIndex = new Index(SeleniumHandler.GetDriver);
            automationIndex.Goto();
            automationIndex.SearchForItem("clothes");            
            SeleniumHandler.TextShouldEqual("0 results have been found.", automationIndex.resultCounter.Text);
        }

        [Test]
        public void SearchAutomationPracticeForDressWithResults()
        {
            Index automationIndex = new Index(SeleniumHandler.GetDriver);
            automationIndex.Goto();
            automationIndex.SearchForItem("dress");            
            SeleniumHandler.TextShouldEqual("7 results have been found.", automationIndex.resultCounter.Text);
        }

        //The VSCode .NET Core Test Explorer debug/run tests links don't work for 
        //this style setup, but "dotnet test" command does run them appropriately 
        [TestCase("clothes", "0 results have been found.", TestName="SearchAutomationPracticeMultiClothesNoResults")]
        [TestCase("dress", "7 results have been found.", TestName="SearchAutomationPracticeMultiDressWithResults")]
        public void SearchAutomationPracticeForMultipleResults(string searchTerm, string results)
        {
            Index automationIndex = new Index(SeleniumHandler.GetDriver);
            automationIndex.Goto();
            automationIndex.SearchForItem(searchTerm);            
            SeleniumHandler.TextShouldEqual(results, automationIndex.resultCounter.Text);
        }
    }
}