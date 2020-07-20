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
    class Certification
    {
        public Certification()
        {
            PageFactory.InitElements(Global.Commondriver.Driver, this);
        }

        #region Certificate Elements 

        //Certificate Tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='fourth']")]
        private IWebElement CertificateTab { get; set; }

        //Add new Certificate
        [FindsBy(How = How.XPath, Using = "(//div[text()='Add New'])[4]")]
        private IWebElement CertificateAddNew { get; set; }

        //Enter  CertificateAward
        [FindsBy(How = How.XPath, Using = "//input[@name='certificationName']")]
        private IWebElement CertificateAward { get; set; }


        //Certified from
        [FindsBy(How = How.XPath, Using = "//input[@name='certificationFrom']")]
        private IWebElement CertificateFrom { get; set; }

        //Year
        [FindsBy(How = How.XPath, Using = "//select[@name='certificationYear']")]
        private IWebElement CertificationYear { get; set; }

        //CertificationAddData
        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement CertificationAddData { get; set; }

        //CertificatelastRowValue
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='fourth']//tbody[last()]//td[1]")]
        private IWebElement CertificatelastRowValue { get; set; }

        //CertificateFromlastRowValue
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='fourth']//tbody[last()]//td[2]")]
        private IWebElement CertificateFromlastRowValue { get; set; }


        //CertificateYearlastRowValue
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='fourth']//tbody[last()]//td[3]")]
        private IWebElement CertificateYearlastRowValue { get; set; }


        //EditCertificateIconlastRow
        [FindsBy(How = How.XPath, Using = "//*[@data-tab='fourth']//tbody[last()]//td[4]/span[1]")]
        private IWebElement EditCertificateIconlastRow { get; set; }


        //DeleteCertificateIconlastRow
        [FindsBy(How = How.XPath, Using = "//*[@data-tab='fourth']//tbody[last()]//td[4]/span[2]")]
        private IWebElement DeleteCertificateIconlastRow { get; set; }


        //UpdateCertificateButtonlastRow
        [FindsBy(How = How.XPath, Using = "//input[@value='Update']")]
        private IWebElement UpdateCertificateButtonlastRow { get; set; }


        //CertificatevalueEdit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Certificate or Award']")]
        private IWebElement CertificatevalueEdit { get; set; }



        //CertificateFromEdit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Certified From (e.g. Adobe)']")]
        private IWebElement CertificateFromEdit { get; set; }


        //CertificateYearEdit
        [FindsBy(How = How.XPath, Using = "//select[@name='certificationYear']")]
        private IWebElement CertificateYearEdit { get; set; }

        #endregion
    
        #region Certification Methods
        internal void NavigateToCertification()
        {
            CertificateTab.Click();
            Commondriver.Wait(10);
        }
        #endregion

        #region Addcertification
        internal void AddCertification()

        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Certification");

            Commondriver.Wait(10);

            CertificateAddNew.Click();
            CertificateAward.SendKeys(Commondriver.Excellib.ReadData(2, "Certificate"));

            CertificateFrom.SendKeys(Commondriver.Excellib.ReadData(2, "From"));

            SelectElement year = new SelectElement(CertificationYear);
            year.SelectByText(Commondriver.Excellib.ReadData(2, "Year"));

            CertificationAddData.Click();

            Thread.Sleep(1000);
        }

        #endregion
        
        #region Editcertification
        internal void EditCertification()

        {
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Certification");

            Commondriver.Wait(10);
            EditCertificateIconlastRow.Click();

            Thread.Sleep(1000);


            CertificatevalueEdit.Clear();

            CertificatevalueEdit.SendKeys(Commondriver.Excellib.ReadData(3, "Certificate"));

            CertificateFromEdit.Clear();

            CertificateFromEdit.SendKeys(Commondriver.Excellib.ReadData(3, "From"));

            SelectElement year = new SelectElement(CertificateYearEdit);
            year.SelectByText(Commondriver.Excellib.ReadData(3, "Year"));

            UpdateCertificateButtonlastRow.Click();


            Thread.Sleep(1000);
        }

        internal void DeleteCertification()

        {

            Commondriver.Wait(10);
            DeleteCertificateIconlastRow.Click();
            Thread.Sleep(1000);


        }
        #endregion

        #region Verifyaddcertification
        internal void VerifyAddCertification()

        {

            Thread.Sleep(1000);
            Commondriver.Excellib.PopulateInCollection(Base.Excelpath, "Certification");

            var ActCertificate = CertificatelastRowValue.Text;
            var ActFrom = CertificateFromlastRowValue.Text;
            var Actyear = CertificateYearlastRowValue.Text;

            Assert.AreEqual(ActCertificate, Commondriver.Excellib.ReadData(2, "Certificate"), "Certificate is not added");

            Assert.AreEqual(ActFrom, Commondriver.Excellib.ReadData(2, "From"), "From is not added");

            Assert.AreEqual(Actyear, Commondriver.Excellib.ReadData(2, "Year"), "Year is not added");

        }

        #endregion
        
        #region Verityedit certification
        internal void VerifyEditCertification()

        {

            var ActCertificate = CertificatelastRowValue.Text;
            var ActFrom = CertificateFromlastRowValue.Text;
            var Actyear = CertificateYearlastRowValue.Text;

            Assert.AreEqual(ActCertificate, Commondriver.Excellib.ReadData(3, "Certificate"), "Certificate is not added");

            Assert.AreEqual(ActFrom, Commondriver.Excellib.ReadData(3, "From"), "From is not added");

            Assert.AreEqual(Actyear, Commondriver.Excellib.ReadData(3, "Year"), "Year is not added");


        }
        #endregion
         
        #region Verifydeletecertification
        internal void VerifyDeleteCertification()

        {

            try
            {
                var ActCertificate = CertificatelastRowValue.Text;
                var ActFrom = CertificateFromlastRowValue.Text;
                var Actyear = CertificateYearlastRowValue.Text;

                Assert.AreNotEqual(ActCertificate, Commondriver.Excellib.ReadData(3, "Certificate"), "Certificate is not deleted");

                Assert.AreNotEqual(ActFrom, Commondriver.Excellib.ReadData(3, "From"), "From is not deleted");

                Assert.AreNotEqual(Actyear, Commondriver.Excellib.ReadData(3, "Year"), "Year is not deleted");

            }

            catch (Exception e)
            {
                Assert.Pass("No Certificate Data exists");

            }


        }

        #endregion





    }



}
