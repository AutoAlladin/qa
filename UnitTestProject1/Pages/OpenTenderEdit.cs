using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace UnitTestProject1.Pages
{
    class OpenTenderEdit : TenderNew
    {
        public OpenTenderEdit(IWebDriver browser) : base(browser)
        {
        }

        /// <summary>
        /// set title, description
        /// </summary>
        public OpenTenderEdit fillText()
        {
            TenderTitle.SendKeys("tender title");
            TenderDescription.SendKeys("tender description");
            return this;
        }
        public OpenTenderEdit fillBudget(Boolean isMultilot) {
            new SelectElement(TenderSelectCurr).SelectByText("UAH");
            TenderPDV.Click();

            if (isMultilot) {
                TenderIsMultilot.Click();
            }
            else
            {
                TenderAmount.SendKeys("54874.14");
                TenderMinStepPerc.SendKeys("1.14");
            }
            return this;
        }
        public OpenTenderEdit fillDate() {
            DateTimeOffset d1 = DateTimeOffset.Now;
            TenderEditStart.SendKeys(d1.ToString("yyyy-MM-dd hh:mm:ss"));
            TenderEditStart.Click();

            TenderEditEnd.SendKeys(d1.AddMinutes(30).ToString("yyyy-MM-dd hh:mm:ss"));
            TenderEditEnd.Click();

            TenderBidStart.SendKeys(d1.AddMinutes(30).AddSeconds(10).ToString("yyyy-MM-dd hh:mm:ss"));
            TenderBidStart.Click();

            TenderBidEnd.SendKeys(d1.AddMinutes(60).ToString("yyyy-MM-dd hh:mm:ss"));
            TenderBidEnd.Click();

            TenderTitle.Click();
            btnNextStep.Click();

            return this;
        }

    }
}
