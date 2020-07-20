using MarsPageF.Config;
using MarsPageF.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsPageF.Global.Commondriver;

namespace MarsPageF.Global
{
    class Base
    {
        
        public static int Browser = Int32.Parse(Resources.Browser);
        public static String Excelpath = Resources.Excelpath;
        public static String Reportpath = Resources.Reportpath;
        public static String ScreenshotPath = Resources.Screenshots;

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        #region setup 
        [SetUp]
        public static void Inititalize()
        {
          Commondriver.Driver = new ChromeDriver();          
            Commondriver.Driver.Manage().Window.Maximize();
            
            if (Resources.Login == "true")
            {
                Signin loginobj = new Signin();
                loginobj.LoginSteps();
            }
            else
            {
                Signup obj = new Signup();
                obj.Register();
            }
            extent = new ExtentReports(Reportpath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(Resources.ReportXMLPath);

        }
        #endregion

        #region teardown
        [TearDown]  
        public static void TearDown()
        {
            // Screenshot
            String image = SaveScreenShotClass.SaveScreenshot(Commondriver.Driver, "Report");
            test.Log(LogStatus.Info, "Image example: " + image);
             //end test. (Reports)
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
           extent.Flush();
           // extent.Close();
            // Close the driver :)            
             Commondriver.Driver.Close();
           //  Commondriver.Driver.Quit();
        }

    }
}

#endregion

    

