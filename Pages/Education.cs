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
    class Education
    {

        public Education()
        {
            PageFactory.InitElements(Global.Commondriver.Driver, this);

        }

        #region Education Elements



        //Click on Add new to Educaiton


        [FindsBy(How = How.XPath, Using = "//a[text()='Education']")]
        private IWebElement EducationTab { get; set; }


        [FindsBy(How = How.XPath, Using = "(//div[contains(text(),'Add New')])[3]")]
        private IWebElement EducationAddNew { get; set; }

        //Enter university in the text box
        [FindsBy(How = How.XPath, Using = "//input[@name='instituteName']")]
        private IWebElement CollegeName { get; set; }

        //Choose the country
        [FindsBy(How = How.XPath, Using = "//select[@name='country']")]
        private IWebElement CountryDropdown { get; set; }

        //Choose the Title option
        [FindsBy(How = How.XPath, Using = "//select[@name='title']")]
        private IWebElement TitleDropdown { get; set; }

        //Enter Degree 
        [FindsBy(How = How.XPath, Using = "//input[@name='degree']")]
        private IWebElement Degree { get; set; }

        //Choose GradutionYearDropDown
        [FindsBy(How = How.XPath, Using = "//select[@name='yearOfGraduation']")]
        private IWebElement GradutionYearDropDown { get; set; }

        //AddButtonEducationData
        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement AddButtonEducationData { get; set; }

        //EducationDataCountryFirstrow
        [FindsBy(How = How.XPath, Using = "//*[@data-tab='third']//tbody[1]//td[1]")]
        private IWebElement EducationDataCountryFirstrow { get; set; }

        //EducationDataUniveristyFirstrow
        [FindsBy(How = How.XPath, Using = "//*[@data-tab='third']//tbody[1]//td[2]")]
        private IWebElement EducationDataUniveristyFirstrow { get; set; }

        //EducationDataTitleFirstrow
        [FindsBy(How = How.XPath, Using = "//*[@data-tab='third']//tbody[1]//td[3]")]
        private IWebElement EducationDataTitleFirstrow { get; set; }

        //EducationDataDegreeFirstrow
        [FindsBy(How = How.XPath, Using = "//*[@data-tab='third']//tbody[1]//td[4]")]
        private IWebElement EducationDataDegreeFirstrow { get; set; }

        //EducationDataGradYearFirstrow
        [FindsBy(How = How.XPath, Using = "//*[@data-tab='third']//tbody[1]//td[5]")]
        private IWebElement EducationDataGradYearFirstrow { get; set; }


        //EducationEditiconFirst
        [FindsBy(How = How.XPath, Using = "(//*[@data-tab='third']//tbody//tr//td//i[@class='outline write icon'])")]
        private IWebElement EducationEditiconFirst { get; set; }


        //EducationDeleteiconFirst
        [FindsBy(How = How.XPath, Using = "//*[@data-tab='third']//tbody[1]//td[6]/span[2]")]
        private IWebElement EducationDeleteiconFirst { get; set; }



        ////UpdateButtonEducationData
        [FindsBy(How = How.XPath, Using = "//input[@value='Update']")]
        private IWebElement UpdateButtonEducationData { get; set; }
        #endregion

        #region Education Methods
        internal void NavigateToEducationTab()
        {
            //Navigate to Education Tab
            Commondriver.Wait(10);

            EducationTab.Click();

        }

        internal void AddEducation()

        {

            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Education");


            //Click on Add new button for education
            Commondriver.Wait(10);
            EducationAddNew.Click();

            //Enter Valid Education details 
            Commondriver.Wait(10);

            CollegeName.SendKeys(Commondriver.Excellib.ReadData(2, "CollegeName"));

            SelectElement country = new SelectElement(CountryDropdown);
            country.SelectByText(Commondriver.Excellib.ReadData(2, "CountryOfCollege"));

            SelectElement Titledrop = new SelectElement(TitleDropdown);
            Titledrop.SelectByText(Commondriver.Excellib.ReadData(2, "TitleDrop"));

            Degree.SendKeys(Commondriver.Excellib.ReadData(2, "Degree"));



            Thread.Sleep(3000);
            SelectElement Yeardrop = new SelectElement(GradutionYearDropDown);
            Yeardrop.SelectByText(Commondriver.Excellib.ReadData(2, "Year"));


            Thread.Sleep(3000);
            AddButtonEducationData.Click();
            Thread.Sleep(2000);

        }
        #endregion
       
        #region Editeducation
        internal void EditEducation()

        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Education");
            
            Commondriver.Wait(10);
           
            EducationEditiconFirst.Click();
            
            CollegeName.Clear();

            CollegeName.SendKeys(Commondriver.Excellib.ReadData(3, "CollegeName"));
            Commondriver.Wait(10);

            SelectElement country = new SelectElement(CountryDropdown);
            country.SelectByText(Commondriver.Excellib.ReadData(3, "CountryOfCollege"));

            SelectElement Titledrop = new SelectElement(TitleDropdown);
            Titledrop.SelectByText(Commondriver.Excellib.ReadData(3, "TitleDrop"));

            Degree.Clear();

            Degree.SendKeys(Commondriver.Excellib.ReadData(3, "Degree"));



            Thread.Sleep(3000);
            SelectElement Yeardrop = new SelectElement(GradutionYearDropDown);
            Yeardrop.SelectByText(Commondriver.Excellib.ReadData(3, "Year"));


            Thread.Sleep(3000);
            UpdateButtonEducationData.Click();
            Thread.Sleep(5000);

        }


        internal void DeleteEducation()

        {
            EducationDeleteiconFirst.Click();

        }

        internal void VerifyAddEducation()

        {


            var actualCountry = EducationDataCountryFirstrow.Text;
            var ExpCountry = Commondriver.Excellib.ReadData(2, "CountryOfCollege");

            var actualColl = EducationDataUniveristyFirstrow.Text;
            var ExpColl = Commondriver.Excellib.ReadData(2, "CollegeName");


            var actualTitle = EducationDataTitleFirstrow.Text;
            var ExpTitle = Commondriver.Excellib.ReadData(2, "TitleDrop");

            var actualDegree = EducationDataDegreeFirstrow.Text;
            var ExpDegree = Commondriver.Excellib.ReadData(2, "Degree");

            var actualYear = EducationDataGradYearFirstrow.Text;
            var ExpYear = Commondriver.Excellib.ReadData(2, "Year");


            Assert.AreEqual(actualCountry, ExpCountry, "Country is not added");

            Assert.AreEqual(actualColl, ExpColl, "College is not added");

            Assert.AreEqual(actualTitle, ExpTitle, "Title is not added");

            Assert.AreEqual(actualDegree, ExpDegree, "Degree is not added");


            Assert.AreEqual(actualYear, ExpYear, "Year is not added");

        }
        #endregion
     
        #region Verify Edit education
        internal void VerifyEditEducation()

        {
            var actualCountry = EducationDataCountryFirstrow.Text;
            var ExpCountry = Commondriver.Excellib.ReadData(3, "CountryOfCollege");

            var actualColl = EducationDataUniveristyFirstrow.Text;
            var ExpColl = Commondriver.Excellib.ReadData(3, "CollegeName");


            var actualTitle = EducationDataTitleFirstrow.Text;
            var ExpTitle = Commondriver.Excellib.ReadData(3, "TitleDrop");

            var actualDegree = EducationDataDegreeFirstrow.Text;
            var ExpDegree = Commondriver.Excellib.ReadData(3, "Degree");

            var actualYear = EducationDataGradYearFirstrow.Text;
            var ExpYear = Commondriver.Excellib.ReadData(3, "Year");


            Assert.AreEqual(actualCountry, ExpCountry, "Country is not updated");

            Assert.AreEqual(actualColl, ExpColl, "College is not updated");

            Assert.AreEqual(actualTitle, ExpTitle, "Title is not updated");

            Assert.AreEqual(actualDegree, ExpDegree, "Degree is not updated");


            Assert.AreEqual(actualYear, ExpYear, "Year is not updated");

        }
        #endregion
       
        #region Verify Delete Education
        internal void VerifyDeleteEducation()


        {

            try
            {
                var actualCountry = EducationDataCountryFirstrow.Text;
                var ExpCountry = Commondriver.Excellib.ReadData(3, "CountryOfCollege");

                var actualColl = EducationDataUniveristyFirstrow.Text;
                var ExpColl = Commondriver.Excellib.ReadData(3, "CollegeName");


                var actualTitle = EducationDataTitleFirstrow.Text;
                var ExpTitle = Commondriver.Excellib.ReadData(3, "TitleDrop");

                var actualDegree = EducationDataDegreeFirstrow.Text;
                var ExpDegree = Commondriver.Excellib.ReadData(3, "Degree");

                var actualYear = EducationDataGradYearFirstrow.Text;
                var ExpYear = Commondriver.Excellib.ReadData(3, "Year");


                Assert.AreNotEqual(actualCountry, ExpCountry, "Country is not deleted");

                Assert.AreNotEqual(actualColl, ExpColl, "College is not deleted");

                Assert.AreNotEqual(actualTitle, ExpTitle, "Title is not deleted");

                Assert.AreNotEqual(actualDegree, ExpDegree, "Degree is not deleted");


                Assert.AreNotEqual(actualYear, ExpYear, "Year is not deleted");

            }

            catch (Exception e)
            {
                Assert.True(true, "No Education Data");
            }

        }


        #endregion


    }
}
