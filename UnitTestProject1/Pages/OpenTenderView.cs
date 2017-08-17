using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Alladin
{
    
    public class OpenTenderView
    {

        private IWebDriver drv;
        public OpenTenderView(IWebDriver _drv){
          drv = _drv;
          PageFactory.InitElements(drv, this);
        }

        [FindsBy(How = How.Id, Using = "publishPurchase")]
        public IWebElement btnPublish;

        [FindsBy(How = How.Id, Using = "purchaseProzorroId")]
        public IWebElement txtUaID;

        public string publish()
        {
            WebDriverWait bigWait = new WebDriverWait(drv, TimeSpan.FromSeconds(60));
            bigWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("page-loader animated fadeIn")));

            btnPublish.Click();
            
            IWebElement uaID = bigWait.Until<IWebElement>(d => d.FindElement(By.Id("purchaseProzorroId")));

            return uaID.Text;

        }

    }
}