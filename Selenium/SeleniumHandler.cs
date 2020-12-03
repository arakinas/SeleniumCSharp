using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using NUnit.Framework;
using System;
using OpenQA.Selenium.Interactions;

namespace SeleniumNet5.Selenium
{
    public class SeleniumHandler
    {
        private static IWebDriver webDriver;
        public static Logger logger;        

        public static string Title
        {
            get { return webDriver.Title; }
        }

        public static IWebDriver GetDriver
        {
            get { return webDriver; }
        }

        public static void Click(IWebElement element)
        {
            string message = $"Click element: ";
            string result = "PASS";
            string resultMessage = string.Empty;
            try
            {
                VerifyElementDisplayed(element);
                message += element.GetAttribute("name");
                element.Click();
            }
            catch (Exception ex)
            {
                message = $"Failed to click {element}";
                resultMessage = ex.ToString();
                Assert.Fail(ex.ToString());
                result = "FAIL";
            }
            finally
            {
                logger.AddLog(message, result, resultMessage);
            }
        }

        public static void Close()
        {
            webDriver.Quit();
        }
    
        public static void Init(string browser = "Chrome", string baseURL = "http://automationpractice.com/index.php")
        {
            switch (browser)
            {
                case "Chrome":
                    {
                        webDriver = new ChromeDriver();
                        break;
                    }

                case "Edge":
                    {
                        webDriver = new EdgeDriver();
                        break;
                    }
            }
            webDriver.Manage().Window.Maximize();
            logger = new Logger();
        }

        public static void Goto(string url)
        {
            webDriver.Url = url;
            VerifyURL(url);
        }

        public static void LogTest(string testName)
        {
            logger.AddLog(testName);
        }

        public static void SendKeys(IWebElement element, string keys)
        {
            string message = $"Sending keys {keys} to: ";
            string result = "PASS";
            string resultMessage = string.Empty;
            try
            {
                VerifyElementDisplayed(element);
                message += element.GetAttribute("name");
                logger.AddLog(message, null, null);
                element.SendKeys(keys);
            }
            catch (Exception ex)
            {
                message = $"Failed to send {keys} to {element}";
                Assert.Fail(ex.ToString());
                result = "FAIL";
            }
            finally
            {
                logger.AddLog(message, result, resultMessage);
            }
        }

        public static void TextShouldEqual(string expected, string actual)
        {
            string message = $"Text: {expected} should equal actual: {actual}";
            string result = "PASS";
            string resultMessage = string.Empty;
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (AssertionException ex)
            {
                if (ex != null)
                {
                    result = "FAIL";
                    resultMessage = ex.ToString();
                }
            }
            finally
            {
                logger.AddLog(message, result, resultMessage);
            }
        }

        public static void VerifyElementDisplayed(IWebElement element)
        {
            if (!element.Displayed)
            {
                try
                {
                    logger.AddLog($"Element {element} not displayed. Moving to element", null, null);
                    Actions actions = new Actions(webDriver);
                    actions.MoveToElement(element);
                    actions.Perform();
                }
                catch (Exception ex)
                {
                    string message = $"Element {element} does not exist";
                    Assert.Fail(message);
                    logger.AddLog(message, "FAIL", ex.ToString());
                }
            }

            if (element.Displayed)
            {
                string elementName = element.GetAttribute("name");
                logger.AddLog($"Found element {elementName}", null, null);
            }
        }

        public static void VerifyURL(string url)
        {
            string PageURL = webDriver.Url;
            string message = "The Current URL and Expected URL are not equal";

            if (PageURL.Equals(url))
            {
                logger.AddLog("Verify URL", "PASS", "URLs are equal");
            }
            else
            {
                logger.AddLog("Verify URL", "FAIL", message);
            }

            Assert.AreEqual(PageURL, url, message);
        }
    }
}