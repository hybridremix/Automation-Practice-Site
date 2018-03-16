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
        public IWebDriver           Chrome;
        public IndexPageObject      IndexPage;
        public ContactPageObject    ContactPage;
        public AuthPageObject       AuthPage;
        public WomensPageObject     WomensPage;

        public IndexPageTest()
        {
            IndexPage = new IndexPageObject("http://automationpractice.com/", "index",
                "Element with ID 'index' cannot be found.");
            ContactPage = new ContactPageObject("http://automationpractice.com/index.php?controller=contact",
                "navigation_page", "Element text is not 'Contact' for the object with class 'navigation_page'.",
                "Contact");
            AuthPage = new AuthPageObject("http://automationpractice.com/index.php?controller=authentication",
                "navigation_page", "Element text is not 'Authentication' for the object with class 'navigation_page'.",
                "Authentication");
            WomensPage = new WomensPageObject("http://automationpractice.com/index.php?id_category=3&controller=category",
                "navigation_page", "Element text is not 'Women' for the object with class 'navigation_page'.",
                "Women");
        }

        [TestMethod]
        [TestCategory("IndexPage")]
        public void OpenContactPage()
        {
            IndexPage.ContactUsLink.Click();
            Assert.AreEqual(ContactPage.VerificationText,
                Chrome.FindElement(By.ClassName(ContactPage.VerificationIdentifier)).Text,
                ContactPage.VerificationAssertMsg);
        }

        [TestMethod]
        [TestCategory("IndexPage")]
        public void OpenAuthPage()
        {
            IndexPage.SignInLink.Click();
            Assert.AreEqual(AuthPage.VerificationText,
                Chrome.FindElement(By.ClassName(AuthPage.VerificationIdentifier)).Text,
                AuthPage.VerificationAssertMsg);
        }

        [TestMethod]
        [TestCategory("IndexPage")]
        public void OpenWomensPage()
        {
            IndexPage.WomensLink.Click();
            Assert.AreEqual(WomensPage.VerificationText,
                Chrome.FindElement(By.ClassName(WomensPage.VerificationIdentifier)).Text,
                WomensPage.VerificationAssertMsg);
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
            IndexPage.WomensLink = Chrome.FindElement(By.LinkText("Women"));
        }

        [TestCleanup]
        public void FinEveryTest()
        {
            Chrome.Close();
            Chrome.Quit();
        }
    }
}
