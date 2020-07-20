using MarsPageF.Global;
using MongoDB.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsPageF.Pages
{
    class Managelisting
    {
        public Managelisting()
        {
            PageFactory.InitElements(Global.Commondriver.Driver, this);
        }
        #region EditShareskills
       
        //Click on Editbutton
        [FindsBy(How = How.XPath, Using = "//i[@class='outline write icon']")]
        private IWebElement Edit { get; set; }

        internal void Editskill()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "EditRecord");
            Edit.Click();
            Commondriver.Wait(10);
            Shareskills S = new Shareskills();
            S.EditSkill();

        }

        #endregion


        #region Managelisting

        //Click on Delete icon
        [FindsBy(How = How.XPath, Using = " //i[@class='remove icon']")]
        private IWebElement Delete { get; set; }

        //Click on yes on pop up 
        [FindsBy(How = How.XPath, Using = "//button[@class='ui icon positive right labeled button']")]
        private IWebElement Popup { get; set; }
      
        internal void Listing()
        {
            Commondriver.Wait(10);
            Delete.Click();
            Popup.Click();

        }
        #endregion


        #region Assertmanage
        internal void Assert_Manage()
        {
            String expectedText = Commondriver.Driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div")).Text;
            Assert.AreEqual(expectedText, "Dance has been deleted");

        }
        #endregion
    }
} 



    

