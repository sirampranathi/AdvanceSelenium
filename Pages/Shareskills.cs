using AutoIt;
using AutoItX3Lib;
using MarsPageF.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsPageF.Pages
{
    internal class Shareskills
    {
        public Shareskills()
        {
            PageFactory.InitElements(Global.Commondriver.Driver, this);

        }
        #region Shareskills Webelement
        //Enter Title in textbox
        [FindsBy(How = How.XPath, Using = "//input[@type='text' and @name='title']")]
        private IWebElement Title { get; set; }

        //Enter Description in Textbox
        [FindsBy(How = How.XPath, Using = "//textarea[ @name='description']")]
        private IWebElement Description { get; set; }

        //Click on Category dropbox
        
        [FindsBy(How = How.XPath, Using = "//select[@name ='categoryId']")]
        private IWebElement Category { get; set; }

        //Click on Subcategory dropbox
        [FindsBy(How = How.XPath, Using = "//select[@name='subcategoryId']")]
        private IWebElement Subcategory { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "(//input[@placeholder='Add new tag'])[1]")]
        private IWebElement Tagname { get; set; }
        //Select service type
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType' and @value='1']")]
        private IWebElement Servicetype { get; set; }

        //Select Location type
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType'][1]")]
        private IWebElement Locationtype { get; set; }

        //Click on Start date from dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='startDate']")]
        private IWebElement Startdate { get; set; }
        //Click on End date from dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']")]
        private IWebElement Enddate { get; set; }
       
        //Enter the Available Days
        [FindsBy(How = How.XPath, Using = "//input[@tabindex='0' and @index='1']")]
        private IWebElement Availabledays { get; set; }
        
        //Enter Start time
        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime']")]
        private IWebElement Starttime { get; set; }

        //Enter End time
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime']")]
        private IWebElement Endtime { get; set; }

        //Select Skill trade option
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades' and @value='false']")]
        private IWebElement Skilltrade { get; set; }

        //Enter amount for credit
        [FindsBy(How = How.XPath, Using = "//input[@name='charge']")]
        private IWebElement Credit { get; set; }
        //Click on File upload
       // [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        //private IWebElement Fileupload { get; set; }
      
        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive' and @value='true']")]
        private IWebElement Active { get; set; }

        //Click on save button
        [FindsBy(How = How.XPath, Using = "//input[@class='ui teal button' and @value='Save']")]
        private IWebElement Save { get; set; }
        #endregion

        #region Entershareskill
        internal void EnterShareSkill()
        {

            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Shareskills");
            Title.SendKeys(Commondriver.Excellib.ReadData(2, "Title"));
            Description.SendKeys(Commondriver.Excellib.ReadData(2, "Description"));
            Commondriver.Wait(10);
            SelectElement catobj = new SelectElement(Category);
            catobj.SelectByText(Commondriver.Excellib.ReadData(2, "Category"));
            Commondriver.Wait(10);
            SelectElement Subcatobj = new SelectElement(Subcategory);
            Subcatobj.SelectByText(Commondriver.Excellib.ReadData(2, "Subcategory"));
            Tagname.SendKeys(Commondriver.Excellib.ReadData(2, "Tagname"));
            Tagname.SendKeys(Keys.Return);
            Servicetype.Click();
            Locationtype.Click();
            Startdate.SendKeys(Commondriver.Excellib.ReadData(2, "Start date"));
            Enddate.SendKeys(Commondriver.Excellib.ReadData(2, "End date"));
            Availabledays.Click();
            Starttime.SendKeys(Commondriver.Excellib.ReadData(2, "Starttime"));
            Endtime.SendKeys(Commondriver.Excellib.ReadData(2, "End time"));
            Skilltrade.Click();
            Credit.SendKeys(Commondriver.Excellib.ReadData(2, "Credit"));
            System.Threading.Thread.Sleep(3000);
            AutoItX3 autoit = new AutoItX3();
            autoit.WinActivate("Open");
            autoit.Send(@"D:\\Mars\\MarsPageF\\file.txt");
            System.Threading.Thread.Sleep(3000);
            autoit.Send("{ENTER}");
            Active.Click();
            Save.Click();
        }
        #endregion

        #region Editshareskill
        internal void EditSkill()
        {

            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "EditRecord");
            Title.SendKeys(Commondriver.Excellib.ReadData(2, "Title"));
            Description.SendKeys(Commondriver.Excellib.ReadData(2, "Description"));
            Commondriver.Wait(10);
            SelectElement catobj = new SelectElement(Category);
            catobj.SelectByText(Commondriver.Excellib.ReadData(2, "Category"));
            Commondriver.Wait(10);
            SelectElement Subcatobj = new SelectElement(Subcategory);
            Subcatobj.SelectByText(Commondriver.Excellib.ReadData(2, "Subcategory"));
            Tagname.SendKeys(Commondriver.Excellib.ReadData(2, "Tagname"));
            Tagname.SendKeys(Keys.Return);
            Tagname.SendKeys(Commondriver.Excellib.ReadData(3, "Tagname"));
            Tagname.SendKeys(Keys.Return);
            Servicetype.Click();
            Locationtype.Click();
            Startdate.SendKeys(Commondriver.Excellib.ReadData(2, "Start date"));
            Enddate.SendKeys(Commondriver.Excellib.ReadData(2, "End date"));
            Availabledays.Click();
            Starttime.SendKeys(Commondriver.Excellib.ReadData(2, "Starttime"));
            Endtime.SendKeys(Commondriver.Excellib.ReadData(2, "End time"));
            Skilltrade.Click();
            Credit.SendKeys(Commondriver.Excellib.ReadData(2, "Credit"));
            /*   Fileupload.Click();
           System.Threading.Thread.Sleep(3000);
           AutoItX3 autoit = new AutoItX3();
           autoit.WinActivate("File upload");
           autoit.Send(@"@D:\\Mars\\MarsPageF\\Dancing");
           System.Threading.Thread.Sleep(3000);
           autoit.Send("{ENTER}");*/
            Active.Click();
            Save.Click();
        }
        #endregion


        #region AssertShareskill        
        [FindsBy(How =How.XPath ,Using = "//td[@class='one wide'][2]")]
        private IWebElement category { get; set; }
        [FindsBy(How =How.XPath,Using = "//td[@class='four wide'][1]")]
        private IWebElement title { get; set; }
        [FindsBy(How =How.XPath,Using = "//td[@class='four wide'][2]")]
        private IWebElement description { get; set; }

        internal void Assert_shareSkill()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Shareskills");
            
            Assert.AreEqual(title.Text,Commondriver.Excellib.ReadData(2,"Title"));
            Assert.AreEqual(description.Text,Commondriver.Excellib.ReadData(2, "Description"));
            Assert.AreEqual(category.Text,Commondriver.Excellib.ReadData(2, "Category"));
            
        }
        #endregion

   /*    internal void Assert_EditshareSkill()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "EditRecord");

            Assert.AreEqual(Mtitle.Text, Commondriver.Excellib.ReadData(2, "Title"));
            Assert.AreEqual(Mdescription.Text, Commondriver.Excellib.ReadData(2, "Description"));
            Assert.AreEqual(Mcategory.Text, Commondriver.Excellib.ReadData(2, "Category"));

        }*/

    }

} 


   

