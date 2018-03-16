namespace Automation_Practice_Site
{
    public class WomensPageObject : WebpageObject
    {
        public WomensPageObject(string webpageURL, string cssIdentifier, string assertMsg, string expectedText = "")
                                    : base(webpageURL, cssIdentifier, assertMsg, expectedText)
        {
        }
    }
}