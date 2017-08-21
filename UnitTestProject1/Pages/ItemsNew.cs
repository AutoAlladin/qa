using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject1.Pages
{
    class ItemsNew
    {
        WebDriverWait bigWait;
        private IWebDriver drv;
        public ItemsNew(IWebDriver _drv)
        {
            drv = _drv;
            bigWait = new WebDriverWait(drv, TimeSpan.FromSeconds(60));
            PageFactory.InitElements(drv, this);
        }

        [FindsBy(How = How.Id, Using = "add_procurement_subject0")]
        public IWebElement btnAddTenderItem { get; set; } 

        [FindsBy(How = How.Id, Using = "add_procurement_subject1")]
        public IWebElement btnAddLotItem { get; set; }

        /// <summary>
        /// основні классифікатори
        /// </summary>
        [FindsBy(How = How.Id, Using = "cls_click_")]
        public IWebElement btnK21 { get; set; }

        /// <summary>
        /// додаткові классифікатори
        /// </summary>

        [FindsBy(How = How.Id, Using = "btn_otherClassifier")]
        public IWebElement btnOtherK { get; set; }

        /// <summary>
        /// суффикс ИД  - 00 для новой позии к тендеру
        ///             - 10 для новой позиции к лоту
        /// </summary>
        private String s = "";



        public void AddNewLotItem(String _s="10") {
            s = _s;
            btnAddLotItem.Click();
            addItem();
            // link to lot;
        }

        public void AddNewTenderItem(String _s="00") {
            s = _s;
            btnAddTenderItem.Click();
            addItem();
        }

        private void addItem()
        {

            PageFactory.InitElements(drv, this);
            fillTextItem();
            fillNomenklatura();
            setDK015();
            setDKKP();
            setDeliveryDate();
            setDeliveryAddress();

            bigWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("page-loader animated fadeIn")));
            drv.FindElement(By.Id("update_" + s)).Click();
            Thread.Sleep(4000);

            bigWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("toast toast-success")));

        }

        private void setDeliveryAddress()
        {
            bigWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("xdsoft_timepicker active")));

            drv.FindElement(By.XPath("//md-switch[@id='is_delivary_"+s+"']/div[2]/span")).Click();

            new SelectElement(drv.FindElement(By.Id("select_countries" + s))).SelectByText("Україна");

            new SelectElement(drv.FindElement(By.Id("select_regions" + s))).SelectByText("Сумська");

            drv.FindElement(By.Id("zip_code_" + s)).SendKeys("654321987");
            drv.FindElement(By.Id("locality_" + s)).SendKeys("Мушколюбів");
            drv.FindElement(By.Id("street_" + s)).SendKeys("Дрозофіли");
            drv.FindElement(By.Id("latutide_" + s)).SendKeys("45.98775");
            drv.FindElement(By.Id("longitude_" + s)).SendKeys("55.97748");

        }

        private void setDeliveryDate()
        {
            drv.FindElement(By.Id("delivery_start_"+s)).SendKeys(DateTimeOffset.Now.AddHours(1).ToString("yyyy-MM-dd hh:mm:ss"));
            drv.FindElement(By.Id("delivery_end_" + s)).SendKeys(DateTimeOffset.Now.AddDays(5).ToString("yyyy-MM-dd hh:mm:ss"));
            drv.FindElement(By.Id("procurementSubject_description" + s)).Click();
        }

        private void setDKKP()
        {
            bigWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("modDialog")));
            bigWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("modal-backdrop fade")));
            btnOtherK.Click();
            bigWait.Until<IWebElement>(d => d.FindElement(By.Id("search-classifier-text"))).SendKeys("000");
            bigWait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='tree']//li[@aria-selected='true']")));
            drv.FindElement(By.Id("add-classifier")).Click();
            bigWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("modal-backdrop fade")));
            bigWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("modDialog")));

        }

        private void setDK015()
        {

            bigWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("modDialog")));
            bigWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("modal-backdrop fade")));
            btnK21.Click();
            bigWait.Until<IWebElement>(d => d.FindElement(By.Id("search-classifier-text"))).SendKeys("30000000-9");
            bigWait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='tree']//li[@aria-selected='true']")));
            drv.FindElement(By.Id("add-classifier")).Click();
            bigWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("modDialog")));
            bigWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("modal-backdrop fade")));
        }

        private void fillNomenklatura()
        {
            drv.FindElement(By.Id("procurementSubject_quantity" + s)).SendKeys("15");
            new SelectElement(drv.FindElement(By.Id("select_unit" + s))).SelectByText("лот");

        }

        private void fillTextItem()
        {
            drv.FindElement(By.Id("procurementSubject_description" + s)).SendKeys("tender Item Description");
        }
        
    }

}
