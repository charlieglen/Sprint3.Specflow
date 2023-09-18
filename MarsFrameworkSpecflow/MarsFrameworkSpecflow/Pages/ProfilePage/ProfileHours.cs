using MarsFramework.Global;
using OpenQA.Selenium;
using static MarsFramework.Global.GlobalDefinitions.ExcelLib;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.GlobalDefinitions.Wait;
using OpenQA.Selenium.Support.UI;

namespace MarsFramework.Pages.ProfilePages
{
    public class ProfileHours : Base
    {
        public ProfileHours()
        {
            PopulateInCollection(ExcelPath, "Profile");
        }

        #region  Find Elements

        //Click on Edit Availability Hour 
        IWebElement EditAvailabilityHours => driver.FindElement(By.XPath("(//I[@class='right floated outline small write icon'])[2]"));

        //Click on Availability Hour dropdown
        IWebElement AvailabilityHoursOpt => driver.FindElement(By.XPath("//SELECT[@class='ui right labeled dropdown']"));

        //Current Availability Hours
        IWebElement CurrentHours => driver.FindElement(By.XPath("(//SPAN)[12]"));

        //Notification Message
        IWebElement NotificationMesssage => driver.FindElement(By.XPath("//div[@class=\"ns-box-inner\"]"));

        #endregion

        private string notificationMessage = "";
        private string hoursValue = "";

        public string GetNotificationMessage()
        {
            return notificationMessage;
        }

        public void SelectHours(string hours)
        {
            //Availability Time option
            wait(30);
            EditAvailabilityHours.Click();
            wait(30);
            SelectElement selectHours = new SelectElement(AvailabilityHoursOpt);
            selectHours.SelectByText(hours);
            wait(30);

            Thread.Sleep(1000);
            driver.Navigate().Refresh();
            Thread.Sleep(1000);

            WaitToBeVisible(driver, "XPath", "(//SPAN)[12]", 50);           
            hoursValue = CurrentHours.Text;
        }

        public string GetHoursValue()
        {
            return hoursValue;
        }

    }
}
