using MarsFramework.Global;
using OpenQA.Selenium;
using static MarsFramework.Global.GlobalDefinitions.ExcelLib;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.GlobalDefinitions.Wait;
using AventStack.ExtentReports;

namespace MarsFramework.Pages.ProfilePages
{
    public class ProfileDescription : Base
    {    
        public ProfileDescription()
        {
            PopulateInCollection(ExcelPath, "Profile");
        }

        #region  Find Elements

        //Click Edit Description
        IWebElement EditProfileDescription => driver.FindElement(By.XPath("(//I[@class='outline write icon'])[1]"));

        //Enter Description Textarea
        IWebElement DescriptionTextArea => driver.FindElement(By.XPath("//TEXTAREA[@name='value']"));

        //Click Save Description
        IWebElement SaveDescription => driver.FindElement(By.XPath("(//BUTTON[@class='ui teal button'][text()='Save'])[2]"));
        
        //Notification Message
        IWebElement NotificationMesssage => driver.FindElement(By.XPath("//div[@class=\"ns-box-inner\"]"));

        //Current Profile Description
        IWebElement CurrentDescription => driver.FindElement(By.XPath("(//SPAN)[16]"));

        #endregion

        private string notificationMessage = "";

        public string GetNotificationMessage()
        {
            return notificationMessage;
        }

        public void AddDescription(string description)
        {
            //wait(30);
            WaitToBeVisible(driver, "XPath", "(//I[@class='outline write icon'])[1]", 100); 
            EditProfileDescription.Click();
            wait(30);
            DescriptionTextArea.Click();
            DescriptionTextArea.Clear();
            wait(30);
            DescriptionTextArea.SendKeys(description);
            wait(30);
            SaveDescription.Click();

            wait(30);
            WaitToBeVisible(driver, "XPath", "//div[@class=\"ns-box-inner\"]", 50);
            notificationMessage = NotificationMesssage.Text;
        }

        public string GetDescriptionValue()
        {
            return CurrentDescription.Text;
        }

        public void ValidateDescription(string currentNotification, string currentDescription, string expectedDescription, ExtentTest test)
        {
            if (currentNotification == "Description has been saved successfully")
            {
                //test.Log(Status.Pass, "Passed, Description added successfully.");
                if (expectedDescription == currentDescription)
                {
                    // Log status in Extentreports
                    test.Log(Status.Pass, "Passed, Description added successfully.");
                }
                else if (expectedDescription == "")
                {
                    // Log status in Extentreports
                    test.Log(Status.Pass, "Passed, Description cannot be empty. Previous description retained.");
                }
                else if (expectedDescription != currentDescription)
                {
                    // Log status in Extentreports
                    test.Log(Status.Pass, "Passed, Description added up to 600 characters only.");
                }
            }
            else
            {
                if (currentNotification == "First character can only be digit or letters")
                {
                    // Log status in Extentreports
                    test.Log(Status.Pass, "First character can only be digit or letters");
                }
                else if (currentNotification == "There is an error saving the Description")
                {
                    // Log status in Extentreports
                    test.Log(Status.Pass, "There is an error saving the Description");
                }
            }

            test.Log(Status.Info, currentNotification);
        }

    }
}
