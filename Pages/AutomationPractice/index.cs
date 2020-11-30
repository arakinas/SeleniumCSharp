using OpenQA.Selenium;

namespace SeleniumNet5.Selenium.Pages.AutomationPractice
{
    public class Index
    {
        private IWebDriver driver;
        private string _searchButton = "#searchbox > button";
        private string _searchTextBox = "search_query_top";
        private string _searchLabel = "//*[@id='center_column']/h1";
        private string _resultCounter = "heading-counter";
        


        public IWebElement searchButton => driver.FindElement(By.CssSelector(_searchButton));
        public IWebElement searchTextBox => driver.FindElement(By.Id(_searchTextBox));
        public IWebElement searchLabel => driver.FindElement(By.XPath(_searchLabel));
        public IWebElement resultCounter => driver.FindElement(By.ClassName(_resultCounter));


        // public IWebElement searchButton = new IWebElement(By.CssSelector(_searchButton));
        // [FindsBy(How = How.CssSelector, Using = "#searchbox > button")]
        // private IWebElement searchButton;

        // [FindsBy(How = How.Id, Using = "search_query_top")]
        // private IWebElement searchTextBox;

        public string webAddress = "http://automationpractice.com/index.php";

        public void SearchForItem(string searchTerm)
        {
            // searchTextBox.SendKeys(searchTerm);
            // searchButton.Click();
            SeleniumHandler.SendKeys(searchTextBox, searchTerm);
            SeleniumHandler.Click(searchButton);
            SeleniumHandler.VerifyElementDisplayed(searchLabel);            
            SeleniumHandler.VerifyElementDisplayed(resultCounter);
        }


        public void Goto()
        {
            SeleniumHandler.Goto(webAddress);
        }

        public Index(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}