using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using UnitTestProject1.Pages;

namespace Alladin
{
    
    public class UnitTest1
    {
        ChromeDriver chd;
        String url = "https://test-gov.ald.in.ua";
        Main mainPage;

        WebDriverWait bigWait;
        //IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.Id("someDynamicElement")));


        [OneTimeSetUp]
        public void TearStart()
        {
            chd = new ChromeDriver();
            chd.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            chd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);

            bigWait = new WebDriverWait(chd, TimeSpan.FromSeconds(60));
        }

        //[TestCase("aladdin.for.test+owner@gmail.com", "zxcvbn00", TestName ="AuthorizationOk", Category = "Owner", Description ="ok") ]
        //[TestCase("aladdin.for.test+owner@gmail.com", "-zxcvbn00", TestName = "AuthorizationOk-pass", Category = "Owner", Description = "failed pass")]
        //[TestCase("-aladdin.for.test+owner@gmail.com", "zxcvbn00", TestName = "AuthorizationOk-login", Category = "Owner", Description = "failed login")]
        public void AuthorizationOk(String _l, String _p)
        {

            ChromeDriver apchh = new ChromeDriver();
            try
            {
                mainPage = new Main(apchh, url);
                String msg = mainPage.openLoginForm().logIn(_l, _p);
                Assert.IsEmpty(msg);
            }
            finally
            {
                apchh.Quit();
            }
            
            


        }

        [Test(Description ="create Below tender") ]
        public void TenderBelow()
        {

            chd.Manage().Window.Size = new System.Drawing.Size(1000, 5000);
            mainPage = new Main(chd, url);
            mainPage.openLoginForm().logIn("aladdin.for.test+owner@gmail.com", "zxcvbn00");
            
            OpenTenderEdit below =mainPage.openCreateMenu(avaliable_for_creating.below)
                                    .fillText()
                                    .fillBudget(false)
                                    .fillDate();

            IWebElement AddItemButton = bigWait.Until<IWebElement>(d => d.FindElement(By.XPath("//*[contains(@id,'add_procurement_subject')]")));
            Assert.Pass("URL: "+chd.Url);

            ItemsNew r = new ItemsNew();
            r.AddNewTenderItem();


        }

        [OneTimeTearDown]
        public void TearDown()
        {
            chd.Quit();
        }
    }
}
