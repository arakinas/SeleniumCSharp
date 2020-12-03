
using NUnit.Framework;
using RestSharp;
using SeleniumNet5.Selenium;

namespace SeleniumNet5.RestSharp
{
    public class RestSharpHandler
    {
        public static RestClient client;
        public static Logger logger;     
        public const string defaultURL = "https://restful-booker.herokuapp.com/";

        public static void Init(string url = defaultURL)
        {
            logger = new Logger();            
            client = new RestClient(url);
        }

        public static RestClient GetClient(string url = defaultURL)
        {            
            if(url != defaultURL)
            {
                client = new RestClient(url);
            }

            return client;
        }

          public static void LogTest(string testName)
        {
            logger.AddLog(testName);
        }

        public static void LogRequest(string request)
        {
            logger.AddLog(request.ToString());
        }

        
        public static void ValueShouldEqual(int expected, int actual)
        {
            ValueShouldEqual(expected.ToString(), actual.ToString());
        }

        public static void ValueShouldEqual(string expected, string actual)
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
    }
}
