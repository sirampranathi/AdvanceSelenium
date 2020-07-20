using MarsPageF.Global;
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
    class Signin
    {
            public Signin()
            {
                PageFactory.InitElements(Global.Commondriver.Driver, this);
            }
            //Click on Signin 
            [FindsBy(How = How.XPath, Using = "//a[ @class='item']")]
            private IWebElement Signintab { get; set; }

            //Enter the Username
            [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
            private IWebElement Username { get; set; }
            //Enter the Password
            [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
            private IWebElement Password { get; set; }
            //Click on Login button
            [FindsBy(How = How.XPath, Using = "//button[@class='fluid ui teal button']")]
            private IWebElement Loginbutton { get; set; }
        
            internal void LoginSteps()
            {
                Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Signin");

                Commondriver.Driver.Navigate().GoToUrl(Commondriver.Excellib.ReadData(2, "Url"));

            //Click on sigin button
                Commondriver.Wait(10);
                Signintab.Click();
           
            //Enter usename
            Commondriver.Wait(10);
            Username.SendKeys(Commondriver.Excellib.ReadData(2, "Username"));
           
            //Enter password
            Commondriver.Wait(10);
            Password.SendKeys(Commondriver.Excellib.ReadData(2, "Password"));
            
            //Click on login button
            Loginbutton.Click();

            }
        }

    }





