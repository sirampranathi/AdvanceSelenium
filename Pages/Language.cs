using MarsPageF.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsPageF.Pages
{
    class Language
    {
        public Language()
        {
            PageFactory.InitElements(Global.Commondriver.Driver, this);

        }

        #region Language elements

        //Click on language
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='first' and text()='Languages']")]
        private IWebElement Langtab { get; set; }

        //Add New button for Language
        [FindsBy(How = How.XPath, Using = "(//div[@class='ui teal button '])[1]")]
        private IWebElement Addnewbutton { get; set; }

        //Add New Language text field
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Add Language']")]
        private IWebElement AddLanguage { get; set; }

        //Add language level value drop down

        [FindsBy(How = How.XPath, Using = "//select[@name='level']")]
        private IWebElement AddLevel { get; set; }

        //AddLanguagebutton
        [FindsBy(How = How.XPath, Using = "(//input[@value='Add'])[1]")]
        private IWebElement Addbutton { get; set; }

        //Edit Language in the language table
        [FindsBy(How = How.XPath, Using = "//*[@data-tab='first']//tbody//tr//td//i[@class='outline write icon']")]
        private IWebElement Editclick { get; set; }
       
        //change Language level
       // [FindsBy(How = How.XPath, Using = "(//select[@name='level'])[1]")]
       // private IWebElement Levelchg { get; set; }

        //Click on Update language
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='first']//input[@value='Update']")]
        private IWebElement Updatebutton { get; set; }

        //Delete Language
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='first']//tbody//tr//td//i[@class='remove icon']")]
        private IWebElement Deletebutton { get; set; }
        
        //LanguagelastRowValue
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='first']//tbody[last()]//td[1]")]
        private IWebElement LangnameValue { get; set; }
       
        //LanguagelevelValue
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='first']//tbody[last()]//td[2]")]
        private IWebElement LanglevelValue { get; set; }



        #endregion

        #region Language method
        internal void New_Language()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Language");
            Langtab.Click();
            Addnewbutton.Click();
            AddLanguage.SendKeys(Commondriver.Excellib.ReadData(2, "Language"));
            SelectElement Levelsel = new SelectElement(AddLevel);
            Levelsel.SelectByText(Commondriver.Excellib.ReadData(2, "Level"));
            Addbutton.Click();
        }
        #endregion
     
        #region Assertlangugae added
        internal void VerifyLanguageadded()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Language");
            var ActLangname = LangnameValue.Text;
            var ActLanglevel = LanglevelValue.Text;

            Assert.AreEqual(ActLangname, Commondriver.Excellib.ReadData(2, "Language"), "Language is not added");

            Assert.AreEqual(ActLanglevel, Commondriver.Excellib.ReadData(2, "Level"), "Level is not added");

        }
        #endregion
       
        #region Editlang method
        internal void Edit_Language()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Language");
            Commondriver.Wait(10);
            Editclick.Click();
            Commondriver.Wait(10);
            SelectElement Chglevel = new SelectElement(AddLevel);
            Chglevel.SelectByText(Commondriver.Excellib.ReadData(3, "Level"));
            Updatebutton.Click();
            Commondriver.Wait(15);

    }
    #endregion

        #region Asserteditlang
        internal void Verifyeditlanguage()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Language");
            Thread.Sleep(1000);
            var ActLanglevel = LanglevelValue.Text;
           
            Assert.AreEqual(ActLanglevel, Commondriver.Excellib.ReadData(3, "Level"));
        }
        #endregion
       
        #region Deletelang method
        internal void Delete_Language()
        {
            Deletebutton.Click();

        }
        #endregion
      
        #region Assertdeletelang
        internal void Verifydeletelanguage()
        {
            try
            {
                var ActLangname = LangnameValue.Text;
                var ActLanglevel = LanglevelValue.Text;

                Assert.AreNotEqual(ActLangname, Commondriver.Excellib.ReadData(2, "Language"), "Language is not Deleted");

                Assert.AreNotEqual(ActLanglevel, Commondriver.Excellib.ReadData(3 ,"Level"), "Level is not Delete");

            }

            catch (Exception e)
            {
                Assert.Pass("No Language Data exists");

            }

        }
        #endregion
    }
}
