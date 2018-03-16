using OpenQA.Selenium;

namespace Automation_Practice_Site
{
    public class IndexPageObject : WebpageObject
    {
        public IWebElement ContactUsLink;
        public IWebElement SignInLink;
        public IWebElement WomensLink;

        public IndexPageObject(string webpageURL, string cssIdentifier, string assertMsg, string expectedText = "")
                                    : base(webpageURL, cssIdentifier, assertMsg, expectedText)
        {
        }
    }
}