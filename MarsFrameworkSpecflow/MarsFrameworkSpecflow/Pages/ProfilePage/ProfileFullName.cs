using MarsFramework.Global;
using OpenQA.Selenium;
using static MarsFramework.Global.GlobalDefinitions.ExcelLib;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.GlobalDefinitions.Wait;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace MarsFramework.Pages.ProfilePages
{
    public class ProfileFullName : Base
    {
        public ProfileFullName()
        {
            PopulateInCollection(ExcelPath, "Profile");
        }

        #region  Find Elements
        //Click on Full Name dropdown
        IWebElement FullNameDropdownBtn => driver.FindElement(By.XPath("(//I[@class='dropdown icon'])[2]"));

        //Click on First Name
        IWebElement FirstName => driver.FindElement(By.XPath("(//INPUT[@type='text'])[2]"));

        //Click on Last Name
        IWebElement LastName => driver.FindElement(By.XPath("(//INPUT[@type='text'])[3]"));

        //Click on Save Full Name button
        IWebElement SaveFullName => driver.FindElement(By.XPath("//BUTTON[@class='ui teal button'][text()='Save']"));

        //Full Name Label
        IWebElement FullName => driver.FindElement(By.XPath("//DIV[@class='title']"));

        //Notification Message
        IWebElement NotificationMesssage => driver.FindElement(By.XPath("//div[@class=\"ns-box-inner\"]"));        

        #endregion

        private string notificationMessage = "";

        public string GetNotificationMessage()
        {
            return notificationMessage;
        }

        public void EditFullName()
        {
            string fName = ReadData(2, "FirstName");
            string lName = ReadData(2, "LastName");
            string fullName= fName + " " + lName;
            string fullNameValue = "";

            //Click on Edit button
            WaitToBeClickable("XPath", "(//I[@class='dropdown icon'])[2]", 30);
            FullNameDropdownBtn.Click();

            wait(350);
            FirstName.Clear();
            wait(250);
            FirstName.Clear();
            FirstName.SendKeys(fName);

            wait(250);
            LastName.Clear();
            wait(250);
            LastName.SendKeys(lName);

            wait(150);
            SaveFullName.Click();
            Thread.Sleep(1000);
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
                        
            WaitToBeVisible(driver, "XPath", "//DIV[@class='title']", 50);
            fullNameValue = FullName.Text;

            if (fullNameValue == fullName)
            {
                test.Log(Status.Info, "Full Name successfully updated to " + fullNameValue);
                Assert.That(FullName.Text == fullName, "Full Name not updated");
            }
            else
            {

                test.Log(Status.Fail, "Full Name Not Updated");
            }
        }
    }
}
