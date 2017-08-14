using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Pages
{
    class ItemsNew
    {

        private IWebDriver drv;
        public ItemsNew(IWebDriver _drv)
        {
            drv = _drv;
        }

        [FindsBy(How =How.Id, Using = "add_procurement_subject0")]
        IWebElement AddTenderItem;

        [FindsBy(How = How.Id, Using = "add_procurement_subject1")]
        IWebElement AddLotItem;
        /// <summary>
        /// суффикс ИД  - 00 для новой позии к тендеру
        ///             - 01 для новой позиции к лоту
        /// </summary>
        private String s = "";

        public void AddNewLotItem() {
            s = "01";
            addItem();
            // link to lot;
        }

        public void AddNewTenderItem() {
            s = "00";
            addItem();
        }

        private void addItem()
        {
            fillTextItem();
           /* fillNomenklatura();
            setDK015();
            setDKKP();
            setDeliveryDate();
            setDeliveryAddress();*/

        }

        private void fillTextItem()
        {
            drv.FindElement(By.Id("procurementSubject_description" + s)).SendKeys("tender Item Description");
        }

       /* "00"
        "procurementSubject_quantity00"
        "procurementSubject_quantity01"*/

    }

}
