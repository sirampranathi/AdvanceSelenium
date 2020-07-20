using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsPageF.Global;
using MarsPageF.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface;
using RelevantCodes.ExtentReports;

namespace MarsPageF.Test

{
    class Program
    {

        [TestFixture]
        [Category("Sprint1")]

        class User : Base
        {
            static void Main(string[] args)
            {

            }
           
            #region Shareskill
            [Test, Description("Adding new record")]
            public void Shareskillpage()
            {

             test = extent.StartTest("click on Share skill on profile page");
            //Navigate to share skill page 
                Profile profobj = new Profile();
                profobj.Assertprofile();
                profobj.Shareclick();
                profobj.Assertshare();

                test = extent.StartTest("Enter on Service listing on Shareskill page");

                //Adding service listing in share skill page    
                Shareskills shareobj = new Shareskills();
                shareobj.EnterShareSkill();
                shareobj.Assert_shareSkill();

            }
            #endregion

            #region Delete Sharedskill
            [Test, Description("Deleting a record")]
            public void Managelist()
            {
                test = extent.StartTest("Navigate on Managelisting on profile page");

                //Navigate to Manage listing page
                Profile profobj = new Profile();
                profobj.ManageClick();
                profobj.AssertManage();
               
                test = extent.StartTest("Delete record in Managelisting page");

                //Deleting the record
                Managelisting Manageobj = new Managelisting();
                Manageobj.Listing();
                Manageobj.Assert_Manage();

            }
            #endregion
           
            #region Edit sharedskill
            [Test, Description("Edit the Record")]
            public void EDitpage()
            {

                test = extent.StartTest("click on Share skill on profile page");
                //Navigate to Manage listing page
                Profile profobj = new Profile();
                profobj.ManageClick();
                profobj.AssertManage();

                test = extent.StartTest("Enter on Service listing on Shareskill page");

                //Editing the record
                Managelisting Editobj = new Managelisting();
                Editobj.Editskill();
               // Manageobj.Assert_Manage();

            }
            #endregion

            #region New Language added
            [Test , Description("Adding new language")]
            public void Newlanguage()
            {
                test = extent.StartTest("Navigated to language tab and added new language");

                Language Langobj = new Language();
                //Adding a new language
                Langobj.New_Language();
               
                test = extent.StartTest("Verified new language added");
               //Verifying language added
                Langobj.VerifyLanguageadded();
           
            
               test = extent.StartTest("Updated existing language");
                //Edited language in language tab
                Langobj.Edit_Language();
              
                test = extent.StartTest("language updates are verified");
                //verify Changes are updated
                Langobj.Verifyeditlanguage();
                    
                test = extent.StartTest("Existing language is deleted");
                //existing  language  record is deleted
                Langobj.Delete_Language();
                
                test = extent.StartTest("verified language has been deleted ");
                //verify language is deleted
                Langobj.Verifydeletelanguage();
            }
            #endregion

            #region New skill added
            
            [Test, Description("Add New skill")]
            public void Newskill()
            {

                test = extent.StartTest("New skill record added");
                Skills Skillobj = new Skills();
                //navigated and added new skill      
                Skillobj.Addskill();
               
                test = extent.StartTest("Verified new skill added");
                //Verified skill has been added
                Skillobj.Verifyaddskill();
                    
                test = extent.StartTest("Edit existing skill");
                //Navigate to skill tab and edit skill record
                Skillobj.EditSkill();
                
                //verify record has been updated
                test = extent.StartTest("Verify skill has been updated");
                Skillobj.VerifyEditskill();

                test = extent.StartTest("Existing skill record is deleted");
                //skill record is deleted
                Skillobj.Deleteskill();
                
                //verify record has been deleted
                test = extent.StartTest("Verify skill is deleted");
                Skillobj.Verifydeleteskill();
           }
            #endregion

            #region Cerification
            [Test, Description("Certification")]

            public void Addcertification()
            {
                Certification CertificObj = new Certification();
                //Navigate to cerification tab
                test = extent.StartTest("Cerification tab clicked");
                CertificObj.NavigateToCertification();
               
                //Add certification
                test = extent.StartTest("Certification has been added");
                CertificObj.AddCertification();

                //Verify Certification added
                test = extent.StartTest("Verify Certification has been added");
                CertificObj.VerifyAddCertification();
                
                //Edit Certification 
                test = extent.StartTest("Edit Certification ");
                CertificObj.EditCertification();
               
                //Verify Certification updated
                test = extent.StartTest("Verify Certification has been updated");
                CertificObj.VerifyEditCertification();
               
                // Certification deleted
                test = extent.StartTest(" Certification has been deleted");
                CertificObj.DeleteCertification();
                
                //Verify Certification has been deleted
                test = extent.StartTest("Verify Certification has been deleted");
                CertificObj.VerifyDeleteCertification();
            }

            #endregion

            #region Education
            [Test,Description("Education")]
            public void Education()
            {
                Education EduObj = new Education();
                // Navigate Education tab
                test = extent.StartTest("navigated to education tab");
                EduObj.NavigateToEducationTab();

                // Add new Education 
                test = extent.StartTest("new  education added");
                EduObj.EditEducation();
                
                // Verify Education added
                test = extent.StartTest("verify education added");
                EduObj.VerifyAddEducation();

                // Edit Education tab
                test = extent.StartTest("Edit education ");
                EduObj.EditEducation();

                // Verify edit Education tab
                test = extent.StartTest("verify edit education ");
                EduObj.VerifyEditEducation();
               
                // Delete Education 
                test = extent.StartTest("Delete  education ");
                EduObj.DeleteEducation();

                // Verify Education deleted
                test = extent.StartTest("Verify education deleted");
                EduObj.NavigateToEducationTab();

            }
            #endregion

            #region Profile title

            [Test, Description("Title")]
            public void Title()
            {
                test = extent.StartTest("User Title is added");
                //Enter user title
                Profile titleobj = new Profile();
                titleobj.Profiletitle();
                test = extent.StartTest("Verify Title is added");
                //Verify title is added
                titleobj.AssertTitle();
            }
            #endregion
          
            #region Description on profilepage
        
            [Test,Description("Description Text")]
            public void Descriptiontext()
            {
                test = extent.StartTest("Description text added ");
                Profile Txtobj = new Profile();
                //New text added
                Txtobj.Description();
                
                test = extent.StartTest("verify new text added");
                //Verify text added
                Txtobj.Asserttext();
            }
            #endregion


            #region User Available time
            [Test, Description("User Availabe time ")]
            public void Availabilityadded()
            {
                test = extent.StartTest("Availabiliity added ");
                Profile Avaiobj= new Profile();
                //user available time added
                Avaiobj.Availabletime();

                test = extent.StartTest("verify new Availabe time added");
                //Verify available time added
                Avaiobj.Verify_Time_saved();
            }
            #endregion

            #region User Available hours
            [Test, Description(" User Available hours")]
            public void Availablehours()
            {
                test = extent.StartTest("Available hours added ");
                Profile Hourobj = new Profile();
                //user available hours added
                Hourobj.AvailableHours();

                test = extent.StartTest("verify hours added");
                //Verify hours added
                Hourobj.Verify_Hours_saved();
            }
            #endregion

            #region Targetearn
           
            [Test, Description("User Target earn")]
            
            public void Targetearn()
            {
                test = extent.StartTest("Target Earn ");
                Profile Earnobj = new Profile();
                //user target earn added
                Earnobj.Targetadd();

                test = extent.StartTest("Verify Target is added");
                //Verify target is  added
                Earnobj.Verify_target_saved();
            }
            #endregion

            #region Searchskill

            [Test,Description( "Search skill")]
            
            public void SearchSkill()
            {
                test = extent.StartTest("User search for skill");
                Profile searchobj = new Profile();
                searchobj.Searchskill();
                searchobj.Verify_searchskill();

            }
            #endregion

        }
    }
    }





