namespace Automation_Practice_Site
{
    public class ContactPageObject : WebpageObject
    {
        public ContactPageObject(string webpageURL, string cssIdentifier, string assertMsg, string expectedText = "")
                                    : base(webpageURL, cssIdentifier, assertMsg, expectedText)
        {
        }
    }
}