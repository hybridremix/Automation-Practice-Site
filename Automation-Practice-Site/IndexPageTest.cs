using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;

namespace Automation_Practice_Site
{
    [TestClass]
    public class IndexPageTest
    {
        public IWebDriver   Chrome;
        public IndexPageObject IndexPage;

        public IndexPageTest()
        {
            IndexPage = new IndexPageObject
            {
                PageURL = "http://automationpractice.com/"
            };
        }

        [TestMethod]
        [TestCategory("IndexPage")]
        public void OpenContactPage()
        {
            IndexPage.ContactUsLink.Click();
            Assert.AreEqual("Contact", Chrome.FindElement(By.ClassName("navigation_page")).Text,
                "Element text is not 'Contact' for the object with class 'navigation_page'.");
        }

        [TestMethod]
        [TestCategory("IndexPage")]
        public void OpenAuthPage()
        {
            IndexPage.SignInLink.Click();
            Assert.AreEqual("Authentication", Chrome.FindElement(By.ClassName("navigation_page")).Text,
                "Element text is not 'Authentication' for the object with class 'navigation_page'.");
        }

        [TestInitialize]
        public void InitEveryTest()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //var resourcesDirectory = Path.GetFullPath(Path.Combine(outputDirectory, @"..\..\..\bin\Debug"));
            Chrome = new ChromeDriver(outputDirectory);

            Chrome.Navigate().GoToUrl(IndexPage.PageURL);
            IndexPage.ContactUsLink = Chrome.FindElement(By.Id("contact-link"));
            IndexPage.SignInLink = Chrome.FindElement(By.ClassName("header_user_info"));
        }

        [TestCleanup]
        public void FinEveryTest()
        {
            Chrome.Close();
            Chrome.Quit();
        }
    }
}
