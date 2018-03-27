using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

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
        public SpecialsPageObject   SpecialsPage;
        public ShopCartPageObject   ShopCartPage;

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
            SpecialsPage = new SpecialsPageObject("http://automationpractice.com/index.php?controller=prices-drop",
                "navigation_page", "Element text is not 'Price Drop' for the object with class 'navigation_page'.",
                "Price drop");
            ShopCartPage = new ShopCartPageObject("http://automationpractice.com/index.php?controller=order",
                "navigation_page", "Element text is not 'Your Shopping Cart' for the object with class 'navigation_page'.",
                "Your shopping cart");
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
        public void OpenShoppingCart()
        {
            IndexPage.ShopCartLink.Click();
            Assert.AreEqual(ShopCartPage.VerificationText,
                Chrome.FindElement(By.ClassName(ShopCartPage.VerificationIdentifier)).Text,
                ShopCartPage.VerificationAssertMsg);
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

        [TestMethod]
        [TestCategory("IndexPage")]
        public void OpenSpecialsPage()
        {
            IndexPage.SpecialsLink.Click();
            Assert.AreEqual(SpecialsPage.VerificationText,
                Chrome.FindElement(By.ClassName(SpecialsPage.VerificationIdentifier)).Text,
                SpecialsPage.VerificationAssertMsg);
        }

        [TestMethod]
        [TestCategory("IndexPage")]
        public void FlipSlides()
        {
            var leftString = Chrome.FindElement(By.Id("homeslider")).GetCssValue("left");
            leftString = leftString.Remove(leftString.Length - 2);
            var leftInteger = int.Parse(leftString);
            Assert.IsTrue(leftInteger <= -779 && leftInteger >= -1558,
                String.Format("The 'homeslider' element's left attribute is {0} and therefore is not displaying 'sample-1'.", leftString));

            IndexPage.HomeSlider.RightArrow.Click();
            leftString = Chrome.FindElement(By.Id("homeslider")).GetCssValue("left");
            leftString = leftString.Remove(leftString.Length - 2);
            leftInteger = int.Parse(leftString);
            Assert.IsTrue(leftInteger <= -1558 && leftInteger >= -2337,
                String.Format("The 'homeslider' element's left attribute is {0} and therefore is not displaying 'sample-2'.", leftString));

            IndexPage.HomeSlider.RightArrow.Click();
            //Assert.IsTrue(IndexPage.HomeSlider.Slides[0].Displayed);
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
            IndexPage.ShopCartLink = Chrome.FindElement(By.PartialLinkText("Cart"));

            IndexPage.HomeSlider.LeftArrow = Chrome.FindElement(By.ClassName("bx-prev"));
            IndexPage.HomeSlider.RightArrow = Chrome.FindElement(By.ClassName("bx-next"));
            for (var i = 0; i < IndexPage.HomeSlider.Slides.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        IndexPage.HomeSlider.Slides[i] = Chrome.FindElement(By.XPath("//*[@alt='sample-1']"));
                        break;
                    case 1:
                        IndexPage.HomeSlider.Slides[i] = Chrome.FindElement(By.XPath("//*[@alt='sample-2']"));
                        break;
                    case 2:
                        IndexPage.HomeSlider.Slides[i] = Chrome.FindElement(By.XPath("//*[@alt='sample-3']"));
                        break;
                    default:
                        continue;

                }
            }
            
            IndexPage.WomensLink = Chrome.FindElement(By.LinkText("Women"));
            IndexPage.SpecialsLink = Chrome.FindElement(By.LinkText("Specials"));
        }

        [TestCleanup]
        public void FinEveryTest()
        {
            Chrome.Close();
            Chrome.Quit();
        }
    }
}
