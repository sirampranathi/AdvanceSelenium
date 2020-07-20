using MarsPageF.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsPageF.Pages
{
    class Signup
    {
        public Signup()
        {
            PageFactory.InitElements(Global.Commondriver.Driver, this);
        }
        #region signup
        //Click on Join
        [FindsBy(How = How.XPath, Using = "//button[@class='ui green basic button']")]
        private IWebElement Jointab { get; set; }
        //Enter the First Name
        [FindsBy(How = How.XPath, Using = "//input[@name='firstName']")]
        private IWebElement Firstname { get; set; }
        //Enter the Last Name
        [FindsBy(How = How.XPath, Using = "//input[@name='lastName']")]
        private IWebElement Lastname { get; set; }
        //Enter the email address
        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement Email { get; set; }

        //Enter the password
        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement Password { get; set; }

        //Confirm password
        [FindsBy(How = How.Name, Using = "//input[@name='confirmPassword']")]
        private IWebElement Confirm { get; set; }

        //Click on Terms and conditions
        [FindsBy(How = How.XPath, Using = "//input[@name='terms']")]
        private IWebElement Terms { get; set; }

        //Click on Join tab
        [FindsBy(How = How.Id, Using = "submit-btn")]
        private IWebElement Join { get; set; }

        #endregion
        internal void Register()
        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Signup");
            //Click on join
            Commondriver.Wait(2);
            Jointab.Click();
            //Enter firstname
            Firstname.SendKeys(Commondriver.Excellib.ReadData(2, "Frist Name"));
            //Enter lastname
            Lastname.SendKeys(Commondriver.Excellib.ReadData(2, "Last name"));
            //Enter email
            Email.SendKeys(Commondriver.Excellib.ReadData(2, "Email"));
            //Enter password
            Password.SendKeys(Commondriver.Excellib.ReadData(2, "Password"));
            //Confirm password
            Confirm.SendKeys(Commondriver.Excellib.ReadData(2, "Confirm password"));
            //Click on terms checkbox
            Terms.Click();
            //click on join
            Join.Click();

        }
    }
}


    

