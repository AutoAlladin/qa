using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnitTestProject1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.Pages
{
    public abstract class  TenderNew
    {
        public TenderNew(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "title")]
        public IWebElement TenderTitle { get; set; }

        [FindsBy(How = How.Id, Using = "description")]
        public IWebElement TenderDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='is_multilot']/div[1]/div[2]")]
        public IWebElement TenderIsMultilot { get; set; }

        [FindsBy(How = How.Id, Using = "select_currencies")]
        public IWebElement TenderSelectCurr { get; set; }

        [FindsBy(How = How.Id, Using = "budget")]
        public IWebElement TenderAmount { get; set; }

        [FindsBy(How = How.Id, Using = "min_step")]
        public  IWebElement TenderMinStep { get; set; }

        [FindsBy(How = How.Id, Using = "min_step_percentage")]
        public IWebElement TenderMinStepPerc { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='is_vat']/div[1]/div[2]/div")]
        public IWebElement TenderPDV { get; set; }

        [FindsBy(How = How.Id, Using = "period_enquiry_start")]
        public IWebElement TenderEditStart { get; set; }

        [FindsBy(How = How.Id, Using = "period_enquiry_end")]
        public IWebElement TenderEditEnd { get; set; }

        [FindsBy(How = How.Id, Using = "period_tender_start")]
        public IWebElement TenderBidStart { get; set; }


        [FindsBy(How = How.Id, Using = "period_tender_end")]
        public IWebElement TenderBidEnd { get; set; }

        [FindsBy(How = How.Id, Using = "next_step")]
        protected IWebElement btnNextStep { get; set; }
    }
}
