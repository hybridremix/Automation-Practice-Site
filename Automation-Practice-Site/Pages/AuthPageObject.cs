namespace Automation_Practice_Site
{
    public class AuthPageObject : WebpageObject
    {
        public AuthPageObject(string webpageURL, string cssIdentifier, string assertMsg, string expectedText = "")
                                    : base(webpageURL, cssIdentifier, assertMsg, expectedText)
        {
        }
    }
}