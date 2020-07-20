using Excel;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace MarsPageF.Global
{
    class Commondriver
    {
        #region WaitforElement 

        //Initialise the browser
        public static IWebDriver Driver { get; set; }
        public static object ExcelLib { get; internal set; }

        public static void Wait(int time)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(ExpectedConditions.ElementIsVisible(by)));
        }
        #endregion

        #region Excel 
        public class Excellib
        {
            static List<Datacollection> DataCol = new List<Datacollection>();

            public class Datacollection
            {
                public int RowNumber { get; set; }
                public string ColName { get; set; }
                public string ColValue { get; set; }
            }


            public static void ClearData()
            {
                DataCol.Clear();
            }


            private static DataTable ExcelToDataTable(string fileName, string SheetName)
            {
                // Open file and return as Stream
                using (System.IO.FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                    {
                        excelReader.IsFirstRowAsColumnNames = true;

                        //Return as dataset
                        DataSet result = excelReader.AsDataSet();
                        //Get all the tables
                        DataTableCollection table = result.Tables;

                        // store it in data table
                        DataTable resultTable = table[SheetName];

                        // return
                        return resultTable;
                    }
                }
            }

            public static string ReadData(int rowNumber, string columnName)
            {
                try
                {

                    rowNumber = rowNumber - 1;
                    string data = (from colData in DataCol
                                   where colData.ColName == columnName && colData.RowNumber == rowNumber
                                   select colData.ColValue).SingleOrDefault();



                    return data.ToString();
                }

                catch (Exception e)
                {
                    Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                    return null;
                }
            }

            public static void PopulateInCollection(string fileName, string SheetName)
            {
                Excellib.ClearData();
                DataTable table = ExcelToDataTable(fileName, SheetName);

                //Iterate through the rows and columns of the Table
                for (int row = 1; row <= table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        Datacollection dtTable = new Datacollection()
                        {
                            RowNumber = row,
                            ColName = table.Columns[col].ColumnName,
                            ColValue = table.Rows[row - 1][col].ToString()
                        };


                        //Add all the details for each row
                        DataCol.Add(dtTable);

                    }
                }

            }

            internal static object ReadData(int v, IWebElement title)
            {
                throw new NotImplementedException();
            }
        }

        internal static void TurnOnWait()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region screenshots
        public class SaveScreenShotClass
        {
            public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) 
            {
                var folderLocation = (Base.ScreenshotPath);

                if (!System.IO.Directory.Exists(folderLocation))
                {
                    System.IO.Directory.CreateDirectory(folderLocation);
                }

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = new StringBuilder(folderLocation);

                fileName.Append(ScreenShotFileName);
                fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                fileName.Append(".jpeg");
                screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
                return fileName.ToString();
            }
        }
        #endregion
    }
}
