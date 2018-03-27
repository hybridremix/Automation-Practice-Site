using OpenQA.Selenium;

namespace Automation_Practice_Site
{
    public class IndexPageObject : WebpageObject
    {
        public IWebElement ContactUsLink    { get; set; }
        public IWebElement SignInLink       { get; set; }
        public IWebElement ShopCartLink     { get; set; }
        public IWebElement WomensLink       { get; set; }
        public IWebElement SpecialsLink     { get; set; }
        public Slider HomeSlider            { get; set; }

        public IndexPageObject(string webpageURL, string cssIdentifier, string assertMsg, string expectedText = "")
                                    : base(webpageURL, cssIdentifier, assertMsg, expectedText)
        {
            HomeSlider = new Slider();
            HomeSlider.Slides = new IWebElement[3];
        }

    }
}