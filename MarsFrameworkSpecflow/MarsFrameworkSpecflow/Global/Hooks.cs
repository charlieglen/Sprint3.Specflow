using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MarsFrameworkSpecflow.Pages;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsFrameworkSpecflow.Global.GlobalDefinitions;

namespace MarsFrameworkSpecflow.Global
{
    [Binding]
    public class Hooks : Base
    {
        [BeforeScenario]
        public void BeforeScenario()
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
