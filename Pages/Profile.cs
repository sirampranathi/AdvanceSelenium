using MarsPageF.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsPageF.Pages
{
    internal class Profile
    {
        public Profile()
        {
            PageFactory.InitElements(Global.Commondriver.Driver, this);

        }
        #region Skill and Manage click elements

        //Click on Shareskills button
        [FindsBy(How = How.XPath, Using = "//a[@class='ui basic green button']")]
        private IWebElement Shareskillbutton { get; set; }

        //Click on Manage listing
        [FindsBy(How = How.XPath, Using = "//a[@class='item' and @href='/Home/ListingManagement']")]
        private IWebElement Managetab { get; set; }
        #endregion

        #region Description elements

        [FindsBy(How = How.XPath, Using = "//h3[@class='ui dividing header']//span[@class='button']")]
        private IWebElement Descripedit { get; set; }
        //Click on text field Enter the text
        [FindsBy(How = How.XPath, Using = "//textarea[@name='value']")]
        private IWebElement Descriptext { get; set; }
        //Click on save text
        [FindsBy(How = How.XPath, Using = "//button[@type='button']")]
        private IWebElement Descripsave { get; set; }
        #endregion

        #region Title elements
        //Click on dropdown for title
        [FindsBy(How = How.XPath, Using = "(//div[@class='title']//i[@class='dropdown icon'])")]
        private IWebElement Dropdown { get; set; }
        //Click and ente on Fname
        [FindsBy(How = How.XPath, Using = "//input[@type='text' and @name='firstName']")]
        private IWebElement Fname { get; set; }
        //Click and enter Lname
        [FindsBy(How = How.XPath, Using = "//input[@type='text' and @name='lastName']")]
        private IWebElement Lname { get; set; }
        //Click on save
        [FindsBy(How = How.XPath, Using = "(//div//button[@class='ui teal button'])")]
        private IWebElement TitleSave { get; set; }
        #endregion

        #region Availabity elements
        //Click availbility edit button
        [FindsBy(How = How.XPath, Using = "(//i[@class='right floated outline small write icon'])[1]")]
        private IWebElement Availedit { get; set; }
        //Select Availble time
        [FindsBy(How = How.XPath, Using = "//select[@name='availabiltyType']")]
        private IWebElement Availtime { get; set; }
        #endregion

        #region Hours element
        //Click on hours edit button
        [FindsBy(How = How.XPath, Using = "(//i[@class='right floated outline small write icon'])[2]")]
        private IWebElement Houredit { get; set; }
        //Select Hours available
        [FindsBy(How = How.XPath, Using = "//select[@class='ui right labeled dropdown']")]
        private IWebElement Availhour { get; set; }
        #endregion

        #region targetelements

        //Click on Earn edit
        [FindsBy(How = How.XPath, Using = "(//i[@class='right floated outline small write icon'])[3]")]
        private IWebElement Earnedit { get; set; }
        //Select Earn target
        [FindsBy(How = How.XPath, Using = "//select[@name='availabiltyTarget']")]
        private IWebElement Targetearn { get; set; }
        #endregion

        #region SearchSkill elements

        [FindsBy(How = How.XPath, Using = "//i[@class='search link icon']")]
        private IWebElement SearchClick { get; set; }
        [FindsBy(How = How.LinkText, Using = "Programming & Tech")]
        private IWebElement Category { get; set; }
        [FindsBy(How = How.XPath, Using = "(//div//a[@class='item subcategory' and contains( text(),'QA')])")]
        private IWebElement Subcategory { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains( text(), 'Online')]")]
        private IWebElement Filter { get; set; }

        #endregion

        #region Title Method
        internal void Profiletitle()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "ProfilePage data");
            Dropdown.Click();
            Commondriver.Wait(10);
            Fname.Clear();
            Fname.SendKeys(Commondriver.Excellib.ReadData(2, "FirstName"));
            Lname.Clear();
            Lname.SendKeys(Commondriver.Excellib.ReadData(2, "LastName"));
            Commondriver.Wait(10);
            TitleSave.Click();
            Commondriver.Wait(10);

        }
        #endregion

        #region Verify_Title_is_added

        [FindsBy(How = How.XPath, Using = "(//div[@class='title' and contains(text(),'Pranathi Siram')])")]
        private IWebElement Actualtext { get; set; }
        internal void AssertTitle()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "ProfilePage data");
            String fname = Commondriver.Excellib.ReadData(2, "FirstName");
            String lname = Commondriver.Excellib.ReadData(2, "LastName");
            String Expectedtext = fname + " " + lname;
            Thread.Sleep(1000);
            Assert.AreEqual(Actualtext.Text, Expectedtext);
        }
        #endregion

        #region Description method
        internal void Description()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "ProfilePage data");
            Descripedit.Click();
            Commondriver.Wait(10);
            Descriptext.Clear();
            Commondriver.Wait(10);
            Descriptext.SendKeys(Commondriver.Excellib.ReadData(2, "Description"));
            Descripsave.Click();
            Commondriver.Wait(10);
        }
        #endregion

        #region Verify_Description_is_added

        [FindsBy(How = How.XPath, Using = "//textarea[@name='value']")]
        private IWebElement Textsaved { get; set; }
        internal void Asserttext()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "ProfilePage data");
            Commondriver.Wait(10);
            Assert.AreEqual(Textsaved.Text, Commondriver.Excellib.ReadData(2, "Description"));
        }
        #endregion

        #region Availability method
        internal void Availabletime()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "ProfilePage data");
            Availedit.Click();
            Commondriver.Wait(10);
            SelectElement Timeavail = new SelectElement(Availtime);
            Timeavail.SelectByText(Commondriver.Excellib.ReadData(2, "Time"));
            Commondriver.Wait(10);
        }
        #endregion

        #region Verify_Time_saved

        [FindsBy(How = How.XPath, Using = "(//div[@class='right floated content'])[2]")]
        private IWebElement Time { get; set; }
        internal void Verify_Time_saved()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "ProfilePage data");
            Commondriver.Wait(10);
            String Actualtime = Time.Text;
            Assert.IsTrue(Actualtime.Contains(Commondriver.Excellib.ReadData(2, "Time")));

        }
        #endregion

        #region Hours method
        internal void AvailableHours()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "ProfilePage data");
            Houredit.Click();
            Commondriver.Wait(10);
            SelectElement Hoursavail = new SelectElement(Availhour);
            Hoursavail.SelectByText(Commondriver.Excellib.ReadData(2, "Hours"));
            Commondriver.Wait(10);

        }
        #endregion

        #region Verify_Hours_saved

        [FindsBy(How = How.XPath, Using = "(//div[@class='right floated content'])[3]")]
        private IWebElement Hours { get; set; }
        internal void Verify_Hours_saved()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "ProfilePage data");
            Commondriver.Wait(10);
            String Actualtime = Hours.Text;
            Assert.IsTrue(Actualtime.Contains(Commondriver.Excellib.ReadData(2, "Hours")));
        }
        #endregion

        #region Target method
        internal void Targetadd()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "ProfilePage data");
            Earnedit.Click();
            Commondriver.Wait(10);
            SelectElement Earntgt = new SelectElement(Targetearn);
            Earntgt.SelectByText(Commondriver.Excellib.ReadData(2, "Target"));
            Commondriver.Wait(10);

        }
        #endregion

        #region Verify_target_added
        [FindsBy(How = How.XPath, Using = "(//div[@class='right floated content'])[4]")]
        private IWebElement Tgtearn { get; set; }
        internal void Verify_target_saved()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "ProfilePage data");
            Commondriver.Wait(10);
            String Actualtime = Tgtearn.Text;
            Commondriver.Wait(10);
            Assert.IsTrue(Actualtime.Contains(Commondriver.Excellib.ReadData(2, "Target")));
        }
        #endregion

        #region SearchSkill method

        internal void Searchskill()
        {
            SearchClick.Click();
            Commondriver.Wait(10);
            Category.Click();
            Commondriver.Wait(15);
            Subcategory.Click();
            Commondriver.Wait(15);
            Filter.Click();
            Commondriver.Wait(15);
        }
        internal void Verify_searchskill()
        {   String Expectedurl = "http://192.168.99.100:5000/Home/Search?cat=ProgrammingTech&subcat=4";
            String URL = Commondriver.Driver.Url;
            Thread.Sleep(1000);
            Assert.AreEqual(URL, Expectedurl);
         }
        
        #endregion
      
        #region Skill and manage methods 
        internal void Shareclick()
        {
            Shareskillbutton.Click();
        }
        internal void ManageClick()
        {
            Managetab.Click();
        }
        #endregion
     
        #region Profile page assertion    
        
        //profile page assertions
        [FindsBy(How = How.XPath, Using = "//a[@class='item' and @href='/']")]
        private IWebElement Profpage { get; set; }
        internal void Assertprofile()
        {
            try 
         { 

            Commondriver.Wait(10);
            Assert.AreEqual(Profpage.Text, "Mars Logo");
            Base.test.Log(LogStatus.Info, "Navigated to profile page ");
            }
            catch
            {
                Base.test.Log(LogStatus.Info, "Navigate to profile page failed");
            }

        }
        #endregion

        #region Shareskill assertion   
        //shareskill page assertions
        internal void Assertshare()
        {
            try
            {
                Commondriver.Wait(10);
                Assert.AreEqual("ServiceListing", Commondriver.Driver.Title);
                Base.test.Log(LogStatus.Info, "Navigated to Service listing page");
            }
            catch
            {
                Base.test.Log(LogStatus.Info,"Navigate to service list page failed");
            }
            }
        #endregion

        #region Manage listing
        //Manage listing page assertions
        [FindsBy(How = How.XPath, Using = "//h2")]
        private IWebElement Managetext { get; set; }
        internal void AssertManage()
        {
            try 
            {
            Commondriver.Wait(10);
            Assert.AreEqual(Managetext.Text, "Manage Listings");
            
                Base.test.Log(LogStatus.Info, "Navigated to Manage listing page");
            }
            catch
            {
                Base.test.Log(LogStatus.Info, "Navigate to Manage listing page failed");
            }
        }
        #endregion








    }
}




