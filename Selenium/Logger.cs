using OpenQA.Selenium;

namespace SeleniumNet5.Selenium
{
    public class Logger
    {
        LogActions logAction;
        string browser;
        string url;
        IWebDriver driver = SeleniumHandler.GetDriver;
        public Logger(string browser)
        {
            this.browser = browser;
            logAction = new LogActions(browser);
        }

        public void AddLog(string description, string result = null, string exception = null)
        {
            logAction.AddLog(description, result, exception);
        }
    }
}
