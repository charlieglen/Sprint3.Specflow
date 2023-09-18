using MarsFramework.Global;
using OpenQA.Selenium;
using static MarsFramework.Global.GlobalDefinitions.ExcelLib;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.GlobalDefinitions.Wait;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;

namespace MarsFramework.Pages.ProfilePages
{
    public class ProfileLanguages : Base
    {
        public ProfileLanguages()
        {
            PopulateInCollection(ExcelPath, "Profile");
        }

        #region  Find Elements

        //Click on Languages Tab
        IWebElement LanguagesTab => driver.FindElement(By.XPath("//A[@class='item active'][text()='Languages']"));

        //Click on Add new button to add new Language
        IWebElement AddNewLanguageBtn => driver.FindElement(By.XPath("(//DIV[@class='ui teal button '][text()='Add New'])[1]"));

        //Enter the Language on text box
        IWebElement AddLanguageName => driver.FindElement(By.XPath("(//INPUT[@type='text'])[4]"));

        //Click language level dropdown button
        IWebElement LanguageLevelBtn => driver.FindElement(By.XPath("//SELECT[@class='ui dropdown']"));

        //Click Add button to save new language
        IWebElement SaveLanguageBtn => driver.FindElement(By.XPath("(//INPUT[@type='button'])[1]"));

        //Click Cancel button to cancel new language entry
        IWebElement CancelLanguageBtn => driver.FindElement(By.XPath("(//INPUT[@type='button'])[2]"));

        //First row in Language to Update
        IWebElement LanguageToUpdate => driver.FindElement(By.XPath("(//I[@class='outline write icon'])[2]"));

        //First row in Language to Delete
        IWebElement LanguageToDelete => driver.FindElement(By.XPath("(//I[@class='remove icon'])[1]"));

        //Notification Message
        IWebElement NotificationMesssage => driver.FindElement(By.XPath("//div[@class=\"ns-box-inner\"]"));

        #endregion


        private string notificationMessage = "";

        public string GetNotificationMessage()
        {
            return notificationMessage;
        }

        public void AddNewLanguage(string lang, string level, string action)
        {
            //Click Language Tab
            wait(30);
            LanguagesTab.Click();

            if (AddNewLanguageBtn.Displayed)
            {
                //Click on Add New Language button
                wait(30);
                AddNewLanguageBtn.Click();

                wait(30);
                //Enter the Language
                AddLanguageName.SendKeys(lang);

                //Set Language Level
                wait(30);
                LanguageLevelBtn.Click();
                wait(30);
                SelectElement selectedLevel = new SelectElement(LanguageLevelBtn);
                selectedLevel.SelectByValue(level);
                wait(30);

                //Click action
                if (action == "Save")
                    SaveLanguageBtn.Click();
                else
                    CancelLanguageBtn.Click();
            }
            wait(30);
            WaitToBeVisible(driver, "XPath", "//div[@class=\"ns-box-inner\"]", 50);
            notificationMessage = NotificationMesssage.Text;
        }

        public void EditLanguage(string lang, string level, string action)
        {
            //Click Language Tab
            wait(30);
            LanguagesTab.Click();

            //Click Edit Language button (first row)
            wait(30);
            LanguageToUpdate.Click();

            wait(30);
            //Clear the Language Textbox
            AddLanguageName.Clear();

            wait(30);
            //Enter the Language
            AddLanguageName.SendKeys(lang);

            //Set Language Level
            wait(30);
            LanguageLevelBtn.Click();
            wait(30);
            SelectElement selectedLevel = new SelectElement(LanguageLevelBtn);
            selectedLevel.SelectByValue(level);
            wait(30);

            //Click action
            if (action == "Save")
                SaveLanguageBtn.Click();
            else
                CancelLanguageBtn.Click();

            wait(30);
            WaitToBeVisible(driver, "XPath", "//div[@class=\"ns-box-inner\"]", 50);
            notificationMessage = NotificationMesssage.Text;
        }

        public void DeleteLanguage()
        {
            //Click Language Tab
            wait(30);
            LanguagesTab.Click();

            //Click Delete Language button (first row)
            wait(30);
            LanguageToDelete.Click();

            wait(30);
            WaitToBeVisible(driver, "XPath", "//div[@class=\"ns-box-inner\"]", 50);
            notificationMessage = NotificationMesssage.Text;
        }

        public void ValidateAddLanguageResult(string message, string expectedLanguage, ExtentTest test)
        {
            if ((message == (expectedLanguage + " has been added to your languages")) ||
            (message == "List is full. Only 4 languages are required.") ||
            (message == "This language is already exist in your language list.") ||
            (message == "Duplicated data") ||
            (message == "This language is already added to your language list.") ||
            (message == "Please enter language and level"))
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

        public void ValidateEditLanguageResult(string message, string expectedLanguage, ExtentTest test)
        {
            if ((message == (expectedLanguage + " has been updated to your languages")) ||
            (message == "This language is already exist in your language list.") ||
            (message == "Duplicated data") ||
            (message == "This language is already added to your language list.") ||
            (message == "Please enter language and level"))
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

        public void ValidateDeleteLanguageResult(string message, ExtentTest test)
        {
            if (message.Contains("has been deleted from your languages"))
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