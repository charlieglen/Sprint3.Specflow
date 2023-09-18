using MarsFramework.Global;
using OpenQA.Selenium;
using static MarsFramework.Global.GlobalDefinitions.ExcelLib;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.GlobalDefinitions.Wait;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;

namespace MarsFramework.Pages.ProfilePages
{
    public class ProfileSkills : Base
    {
        public ProfileSkills()
        {
            PopulateInCollection(ExcelPath, "Profile");
        }

        #region  Find Elements

        //Click on Skills Tab
        IWebElement SkillsTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));

        //Click on Add new to add new skill
        IWebElement AddNewSkillBtn => driver.FindElement(By.XPath("//DIV[@class='ui teal button'][text()='Add New']"));

        //Enter the Skill on text box
        IWebElement AddSkillName => driver.FindElement(By.XPath("(//INPUT[@type='text'])[4]"));

        //Click on skill level dropdown
        IWebElement SkillLevelBtn => driver.FindElement(By.XPath("//SELECT[@class='ui fluid dropdown']"));

        //Add Skill
        IWebElement SaveSkillBtn => driver.FindElement(By.XPath("(//INPUT[@type='button'])[1]"));

        //Click Cancel button to cancel new skill entry
        IWebElement CancelSkillBtn => driver.FindElement(By.XPath("(//INPUT[@type='button'])[2]"));

        //First row in Skills to Update
        IWebElement SkillToUpdate => driver.FindElement(By.XPath("(//I[@class='outline write icon'])[4]"));

        //First row in Skills to Delete
        IWebElement SkillToDelete => driver.FindElement(By.XPath("(//I[@class='remove icon'])[3]"));
        
        //Notification Message
        IWebElement NotificationMesssage => driver.FindElement(By.XPath("//div[@class=\"ns-box-inner\"]"));

        #endregion

        private string notificationMessage = "";

        public string GetNotificationMessage()
        {
            return notificationMessage;
        }

        public void AddNewSkill(string skill, string level, string action)
        {
            //Click Skills Tab
            Wait.WaitToBeClickable("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 50);
            SkillsTab.Click();

            if (AddNewSkillBtn.Displayed)
            {
                //Click on Add New Skill Button
                wait(30);
                AddNewSkillBtn.Click();
                //Enter the skill 
                AddSkillName.SendKeys(skill);

                //Click the skill level dropdown
                wait(30);
                SkillLevelBtn.Click();
                wait(30);
                SelectElement selectedLevel = new SelectElement(SkillLevelBtn);
                selectedLevel.SelectByValue(level);
                wait(30);

                //Click action
                if (action == "Save")
                    SaveSkillBtn.Click();
                else
                    CancelSkillBtn.Click();
            }

            wait(30);
            WaitToBeVisible(driver, "XPath", "//div[@class=\"ns-box-inner\"]", 50);
            notificationMessage = NotificationMesssage.Text;
        }

        public void EditSkill(string lang, string level, string action)
        {
            //Click Skills Tab
            Wait.WaitToBeClickable("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 50);
            SkillsTab.Click();

            //Click Edit Skill button (first row)
            wait(30);
            SkillToUpdate.Click();

            wait(30);
            //Clear the Skill Name
            AddSkillName.Clear();

            wait(30);
            //Enter the Skill
            AddSkillName.SendKeys(lang);

            //Set Skill Level
            wait(30);
            SkillLevelBtn.Click();
            wait(30);
            SelectElement selectedLevel = new SelectElement(SkillLevelBtn);
            selectedLevel.SelectByValue(level);
            wait(30);

            //Click action
            if (action == "Save")
                SaveSkillBtn.Click();
            else
                CancelSkillBtn.Click();

            wait(30);
            WaitToBeVisible(driver, "XPath", "//div[@class=\"ns-box-inner\"]", 50);
            notificationMessage = NotificationMesssage.Text;
        }

        public void DeleteSkill()
        {
            //Click Skills Tab
            Wait.WaitToBeClickable("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 50);
            SkillsTab.Click();

            //Click Delete Skill button (first row)
            wait(30);
            SkillToDelete.Click();

            wait(30);
            WaitToBeVisible(driver, "XPath", "//div[@class=\"ns-box-inner\"]", 50);
            notificationMessage = NotificationMesssage.Text;
        }

        public void ValidateAddSkillResult(string message, string expectedSkill, ExtentTest test)
        {
            if ((message == (expectedSkill + " has been added to your skills")) ||
            (message == "undefined") ||
            (message == "This skill is already exist in your skill list.") ||
            (message == "Duplicated data") ||
            (message == "Please enter skill and experience level"))
            {
                // Log status in Extentreports
                test.Log(Status.Pass, "Action successful");
                test.Log(Status.Info, message);
            }
            else
            {
                // Log status in Extentreports
                test.Log(Status.Fail, "Action unsuccessful");
                test.Log(Status.Info, message);
            }

        }

        public void ValidateEditSkillResult(string message, string expectedSkill, ExtentTest test)
        {
            if ((message == (expectedSkill + " has been updated to your skills")) ||
            (message == "This skill is already exist in your skill list.") ||
            (message == "Duplicated data") ||
            (message == "Please enter skill and experience level"))
            {
                // Log status in Extentreports
                test.Log(Status.Pass, "Action successful");
                test.Log(Status.Info, message);
            }
            else
            {
                // Log status in Extentreports
                test.Log(Status.Fail, "Action unsuccessful");
                test.Log(Status.Info, message);
            }
        }

        public void ValidateDeleteSkillResult(string message, ExtentTest test)
        {
            if (message.Contains("has been deleted from your Skills"))
            {
                // Log status in Extentreports
                test.Log(Status.Pass, "Action successful");
                test.Log(Status.Info, message);
            }
            else
            {
                // Log status in Extentreports
                test.Log(Status.Fail, "Action unsuccessful");
                test.Log(Status.Info, message);
            }
        }        
    }
}
