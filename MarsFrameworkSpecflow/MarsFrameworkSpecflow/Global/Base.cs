using AventStack.ExtentReports;
using MarsFrameworkSpecflow.Config;
using OpenQA.Selenium;

namespace MarsFrameworkSpecflow.Global
{
    public class Base
    {
        //Initialize resource paths
        public static string ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        public static string ReportXMLPath = MarsResource.ReportXMLPath;
        public static int testRow = 1;

        //Initialize extent reports
        public static ExtentTest test;
        public static ExtentReports extent = new ExtentReports();

        //public static IWebDriver driver;
        public static IWebDriver driver;

    }

} 