using ExcelDataReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Data;
using System.Text;

namespace MarsFrameworkSpecflow.Global
{

    class GlobalDefinitions : Base
    {
        //Initialise the browser
        //public static IWebDriver driver { get; set; }

        #region WaitforElement 
        public class Wait
        {
            public static void WaitToBeVisible(string locatorType, string locatorValue, int seconds)
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));

                if (locatorType == "XPath")
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
                }
                if (locatorType == "Id")
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
                }
                if (locatorType == "CssSelector")
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));
                }

            }

            public static void WaitToBeClickable(string locatorType, string locatorValue, int seconds)
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));

                if (locatorType == "XPath")
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
                }
                if (locatorType == "Id")
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
                }
                if (locatorType == "CssSelector")
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));
                }

            }
        }
        #endregion

        #region Excel 

        public class ExcelLib
        {
            //Creating the collection we will use to store data 
            static List<Datacollection> dataCol = new List<Datacollection>();

            public static void PopulateInCollection(string fileName, string SheetName)
            {
                ExcelLib.ClearData();
                DataTable table = ExcelToDataTable(fileName, SheetName);

                //Iterate through the rows and columns of the Table
                for (int row = 1; row <= table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        Datacollection dtTable = new Datacollection()
                        {
                            rowNumber = row,
                            colName = table.Columns[col].ColumnName,
                            colValue = table.Rows[row - 1][col].ToString()
                        };

                        //Add all the details for each row
                        dataCol.Add(dtTable);
                    }
                }
            }
            public static void ClearData()
            {
                dataCol.Clear();
            }

            private static DataTable ExcelToDataTable(string fileName, string sheetName)
            {
                //Open system file amd returns it as a stream 
                //Register encoding provider to avoid "No data is available for encoding 1252" error
                //"System.Text.Encoding.CodePages" nuget package needs to be installed for this to work
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                // Open file and return as Stream
                using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });

                        //Get all the tables
                        var table = result.Tables;
                        // store it in data table
                        var resultTable = table[sheetName];
                        return resultTable;
                    }
                }
            }
            public class Datacollection
            {
                public int rowNumber { get; set; }
                public string colName { get; set; }
                public string colValue { get; set; }
            }


            public static string ReadData(int rowNumber, string columnName)
            {
                try
                {
                    //Retriving Data using LINQ to reduce much of iterations

                    rowNumber = rowNumber - 1;
                    string data = (from colData in dataCol
                                   where colData.colName == columnName && colData.rowNumber == rowNumber
                                   select colData.colValue).SingleOrDefault();

                    //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                    return data.ToString();
                }

                catch (Exception e)
                {

                    Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                    return null;
                }
            }
        }
        #endregion

        #region screenshots
        public class SaveScreenShotClass
        {
            public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
            {
                var folderLocation = (Base.ScreenshotPath);

                if (!System.IO.Directory.Exists(folderLocation))
                {
                    System.IO.Directory.CreateDirectory(folderLocation);
                }

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = new StringBuilder(folderLocation);

                fileName.Append(ScreenShotFileName);
                fileName.Append(DateTime.Now.ToString("_yyyy-MM-dd_HHmmss"));
                fileName.Append(".png");
                screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Png);
                return fileName.ToString();
            }
        }

        #endregion
    }
}

