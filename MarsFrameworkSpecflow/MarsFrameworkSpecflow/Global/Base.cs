using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MarsFrameworkSpecflow.Config;
using MarsFrameworkSpecflow.Pages;
using OpenQA.Selenium.Chrome;
using static MarsFrameworkSpecflow.Global.GlobalDefinitions;
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

        public static IWebDriver driver;

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "LogIn");

            //Extent Report
            var htmlReporter = new ExtentHtmlReporter(ReportPath);
            htmlReporter.LoadConfig(ReportXMLPath);
            extent.AttachReporter(htmlReporter);

            //Open browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Link"));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Log in or Sign up
            LoginPage loginPagePbj = new LoginPage();
            loginPagePbj.LogInActions();
            Task.Delay(3000).Wait();
            string currentURL = driver.Url;
            if (currentURL != "http://localhost:5000/Account/Profile")
            {
                SignupPage signupobj = new SignupPage();
                signupobj.SignUp();
                test.Log(Status.Fail, "Invalid Credentials, Please try again. No account? Please sign up.");
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            string img = SaveScreenShotClass.SaveScreenshot(driver, "Screenshot");
            test.AddScreenCaptureFromPath(img);
            extent.Flush();
            driver.Quit();
        }
    }

}