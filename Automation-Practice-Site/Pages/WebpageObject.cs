namespace Automation_Practice_Site
{
    public class WebpageObject
    {
        public string PageURL                   { get; set; }
        public string VerificationIdentifier    { get; set; }
        public string VerificationText          { get; set; }
        public string VerificationAssertMsg     { get; set; }

        public WebpageObject(string webpageURL, string cssIdentifier, string assertMsg, string expectedText = "")
        {
            PageURL = webpageURL;
            VerificationIdentifier = cssIdentifier;
            VerificationText = expectedText;
            VerificationAssertMsg = assertMsg;
        }
    }
}