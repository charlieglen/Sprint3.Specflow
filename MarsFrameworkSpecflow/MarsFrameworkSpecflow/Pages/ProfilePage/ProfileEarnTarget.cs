using MarsFramework.Global;
using OpenQA.Selenium;
using static MarsFramework.Global.GlobalDefinitions.ExcelLib;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.GlobalDefinitions.Wait;
using OpenQA.Selenium.Support.UI;

namespace MarsFramework.Pages.ProfilePages
{
    public class ProfileEarnTarget : Base
    {
        public ProfileEarnTarget()
        {
            PopulateInCollection(ExcelPath, "Profile");
        }

        #region  Find Elements

        //Click on edit Earn Target
        IWebElement EditSalary => driver.FindElement(By.XPath("(//I[@class='right floated outline small write icon'])[3]"));

        //Click on salary option
        IWebElement SalaryOpt => driver.FindElement(By.XPath("//SELECT[@class='ui right labeled dropdown']"));

        //Current Earn Target Value
        IWebElement CurrentSalaryValue => driver.FindElement(By.XPath("(//SPAN)[14]"));

        //Notification Message
        IWebElement NotificationMesssage => driver.FindElement(By.XPath("//div[@class=\"ns-box-inner\"]"));

        #endregion

        private string notificationMessage = "";
        private string salaryValue = "";

        public void EarnTarget(string salary)
        {
            //Availability Time option
            wait(30);
            EditSalary.Click();
            wait(30);
            SelectElement earnTargetValue = new SelectElement(SalaryOpt);
            earnTargetValue.SelectByText(salary);
            wait(50);

            Thread.Sleep(1000);
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
                        
            WaitToBeVisible(driver, "XPath", "(//SPAN)[14]", 50);
            salaryValue = CurrentSalaryValue.Text;
        }
        public string GetEarnTargetValue()
        {
            return salaryValue;            
        }
        public string GetNotificationMessage()
        {
            return notificationMessage;
        }

    }
}
