using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using NUnit.Framework;

namespace UnitTestProject1.Pages
{
    class Main
    {
        private readonly IWebDriver driver;

        public Main(IWebDriver browser, string _url)
        {
            this.driver = browser;
            this.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            //this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(_url);
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "findbykeywords" )]
        IWebElement searchInput { get; set; }

        [FindsBy(How = How.Id, Using = "liLoginNoAuthenticated")]
        IWebElement loginMenu { get; set; }

        [FindsBy(How = How.Id, Using = "butLoginPartial")]
        IWebElement loginLink { get; set; }

        [FindsBy(How = How.Id, Using = "btn_create_purchase")]
        IWebElement createButton { get; set; }

        [FindsBy(How=How.XPath, Using = "//a[@href='/Purchase/Create/BelowThreshold']")]
        IWebElement BelowThreshold { get; set; }

        public Login openLoginForm()
        {
            loginMenu.Click();
            loginLink.Click();
            return new Login(driver);

        }

        public OpenTenderEdit openCreateMenu(avaliable_for_creating _a)
        {
            Assert.That(createButton, Is.Not.Null, "Нету кнопки ((( btn_create_purchase");
            createButton.Click();
            switch (_a)
            {
                case avaliable_for_creating.below:
                    BelowThreshold.Click();
                    return new OpenTenderEdit(driver);
                    break;
                default:
                    return null;
            }
        }
    }
}

enum avaliable_for_creating
{
    below
}
