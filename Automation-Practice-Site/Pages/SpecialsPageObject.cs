namespace Automation_Practice_Site
{
    public class SpecialsPageObject : WebpageObject
    {
        public SpecialsPageObject(string webpageURL, string cssIdentifier, string assertMsg, string expectedText = "")
                                    : base(webpageURL, cssIdentifier, assertMsg, expectedText)
        {
        }
    }
}