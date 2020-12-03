using OpenQA.Selenium;

namespace SeleniumNet5.Selenium
{
    public class Logger
    {
        LogActions logAction;
        string url;
        IWebDriver driver = SeleniumHandler.GetDriver;
        public Logger()
        {
            logAction = new LogActions();
        }

        public void AddLog(string description, string result = null, string exception = null)
        {
            logAction.AddLog(description, result, exception);
        }
    }
}
