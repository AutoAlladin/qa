using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.Pages
{
    public class Login
    {
        public Login(IWebDriver browser) {
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement login { get; set; }
        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement pass { get; set; }
        [FindsBy(How = How.Id, Using = "submitLogin")]
        public IWebElement loginButton { get; set; }

        [FindsBy(How=How.XPath, Using = "//div[@class='validation-summary-errors text-danger']/ul/li")]
        public IWebElement errorMessage { get; set; }

        public String logIn(String _login, String _pass)
        {
            this.login.SendKeys(_login);
            this.pass.SendKeys(_pass);
            this.loginButton.Click();
            if (errorMessage == null) return "";
            else
            {
                String errMsg = "";
                try {
                    errMsg = errorMessage.Text;
                }
                catch (NoSuchElementException) {
                    errMsg = "";
                }
                return errMsg;
            }
        }
    }
}
