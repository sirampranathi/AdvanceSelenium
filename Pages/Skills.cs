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
    class Skills
    {
        public Skills()
        {
            PageFactory.InitElements(Global.Commondriver.Driver, this);

        }

        #region Skill elements
        //click on skill tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='second']")]
       private IWebElement Skilltab {get;set;}
        //Click on Addnew button
       [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//div[@class='ui teal button' and text()='Add New']")]
       private IWebElement Addnewbutton {get;set;}
        // Enter New skill name
       [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//input[@placeholder='Add Skill']")]
       private IWebElement Skillname {get;set;}
        //Enter new skill Level 
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//select[@name='level']")]
       private IWebElement Skilllevel {get;set;}
        //Click on add button
       [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//input[@value='Add']")]
       private IWebElement Addbutton {get;set;}
        //Skill Editbutton
        [FindsBy(How = How.XPath, Using = "//*[@data-tab='second']//table//tbody//tr//td[3]//i[@class='outline write icon']")]
        private IWebElement Editbutton { get; set; }
        //Update button
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//table//tr//td//input[@value='Update']")]
        private IWebElement Updatebutton { get; set; }
        //Delete button
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//table//tr//td//i[@class='remove icon']")]
        private IWebElement Deletebutton { get; set; }
       
        //SkillNameValue
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//tbody[last()]//td[1]")]
        private IWebElement Skillnamevalue { get; set; }
        
        //SkilllevelValue
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//tbody[last()]//td[2]")]
        private IWebElement Skilllevelvalue { get; set; }


        #endregion

        #region Addskill method
        internal void Addskill()
     {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Skills");
            Skilltab.Click();
            Addnewbutton.Click();
            Skillname.SendKeys(Commondriver.Excellib.ReadData(2, "Skill"));
            SelectElement Levelskill = new SelectElement(Skilllevel);
            Levelskill.SelectByText(Commondriver.Excellib.ReadData(2, "Level"));
            Commondriver.Wait(10);
            Addbutton.Click();
            Commondriver.Wait(20);
     }
        #endregion
       
        #region Assertaddskill
        
        internal void Verifyaddskill()
       {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Skills");
           
            Commondriver.Wait(20);

            var ActSkillname = Skillnamevalue.Text;
            var ActSkilllevel = Skilllevelvalue.Text;

            Assert.AreEqual(ActSkillname, Commondriver.Excellib.ReadData(2, "Skill"), "Skill name is not added");

            Assert.AreEqual(ActSkilllevel, Commondriver.Excellib.ReadData(2, "Level"), "Skill level is not added");

        }
    #endregion
   
        #region Editskill method
      internal void EditSkill()
      {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Skills");
            Commondriver.Wait(15);
            Editbutton.Click();
            Skillname.Clear();
            Commondriver.Wait(15);
            Skillname.SendKeys(Commondriver.Excellib.ReadData(3, "Skill"));
            Updatebutton.Click();
            Commondriver.Wait(15);

      }
        #endregion
       
        #region Asserteditskill
        internal void VerifyEditskill()
       {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Skills");
            Commondriver.Wait(15);

            var ActSkillname = Skillnamevalue.Text;

            Assert.AreEqual(ActSkillname, Commondriver.Excellib.ReadData(3, "Skill"), "Skill name is not Changed");


        }

        #endregion

        #region Skill delete
        internal void Deleteskill()
     {
            Commondriver.Wait(15);
            Deletebutton.Click();
      }
        #endregion
       
        #region Assertskilldelete
         internal void Verifydeleteskill()
      {
             Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Skills");
             Commondriver.Wait(10);

            var ActSkillname = Skillnamevalue.Text;
            var ActSkilllevel = Skilllevelvalue.Text;

           Assert.AreNotEqual(ActSkillname, Commondriver.Excellib.ReadData(3, "Skill"), "Skill name is not deleted");

            Assert.AreNotEqual(ActSkilllevel, Commondriver.Excellib.ReadData(2, "Level"), "Skill level is not deleted");

        }
        #endregion

    }
}

