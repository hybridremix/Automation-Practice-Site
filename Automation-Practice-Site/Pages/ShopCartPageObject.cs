namespace Automation_Practice_Site
{
    public class ShopCartPageObject : WebpageObject
    {
        public ShopCartPageObject(string webpageURL, string cssIdentifier, string assertMsg, string expectedText = "")
                                    : base(webpageURL, cssIdentifier, assertMsg, expectedText)
        {
        }

    }
}