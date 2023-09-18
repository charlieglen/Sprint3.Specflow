using MarsFramework.Global;
using OpenQA.Selenium;
using static MarsFramework.Global.GlobalDefinitions.ExcelLib;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.GlobalDefinitions.Wait;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;

namespace MarsFramework.Pages.ProfilePages
{
    public class ProfileEducation : Base
    {
        public ProfileEducation()
        {
            PopulateInCollection(ExcelPath, "Profile");
        }

        #region  Find Elements

        //Click on Education Tab
        IWebElement EducationTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));

        //Click on Add new to Education
        IWebElement AddNewEducationBtn => driver.FindElement(By.XPath("(//DIV[@class='ui teal button '])[2]"));

        //Enter university in the text box
        IWebElement EnterUniversityName => driver.FindElement(By.XPath("(//INPUT[@type='text'])[4]"));

        //Choose the Country dropdown
        IWebElement ChooseCountryBtn => driver.FindElement(By.XPath("(//SELECT[@class='ui dropdown'])[1]"));

        //Click on Title dropdown
        IWebElement ChooseTitleBtn => driver.FindElement(By.XPath("(//SELECT[@class='ui dropdown'])[2]"));

        //Degree
        IWebElement Degree => driver.FindElement(By.XPath("(//INPUT[@type='text'])[5]"));

        //Year of graduation
        IWebElement DegreeYear => driver.FindElement(By.XPath("(//SELECT[@class='ui dropdown'])[3]"));

        //Click on Add Education details button
        IWebElement SaveEducationBtn => driver.FindElement(By.XPath("(//INPUT[@type='button'])[1]"));

        //Click Cancel button to cancel new education entry
        IWebElement CancelEducationBtn => driver.FindElement(By.XPath("(//INPUT[@type='button'])[2]"));

        //First row in Education to Update
        IWebElement EducationToUpdate => driver.FindElement(By.XPath("(//I[@class='outline write icon'])[5]"));

        //First row in Education to Delete
        IWebElement EducationToDelete => driver.FindElement(By.XPath("(//I[@class='remove icon'])[4]"));

        //Notification Message
        IWebElement NotificationMesssage => driver.FindElement(By.XPath("//div[@class=\"ns-box-inner\"]"));

        #endregion

        private string notificationMessage = "";

        public string GetNotificationMessage()
        {
            return notificationMessage;
        }

        public void AddNewEducation(string university, string country, string title, string degree, string degreeYear, string action)
        {
            //Click Education Tab
            wait(30);
            EducationTab.Click();

            if (AddNewEducationBtn.Displayed)
            {
                wait(30);
                //Click Add Education button
                AddNewEducationBtn.Click();

                wait(30);
                //Enter the University
                EnterUniversityName.SendKeys(university);

                if (country != "")
                {
                    //Choose Country
                    wait(30);
                    ChooseCountryBtn.Click();
                    wait(500);
                    SelectElement selectedCountry = new SelectElement(ChooseCountryBtn);
                    selectedCountry.SelectByValue(country);
                }

                if (title != "")
                {
                    //Choose Title
                    wait(30);
                    ChooseTitleBtn.Click();
                    wait(50);
                    SelectElement selectedTitle = new SelectElement(ChooseTitleBtn);
                    selectedTitle.SelectByValue(title);
                }

                //Enter Degree
                wait(30);
                Degree.SendKeys(degree);

                if (degreeYear != "")
                {
                    //Year of Graduation
                    wait(30);
                    DegreeYear.Click();
                    wait(30);
                    SelectElement selectedYear = new SelectElement(DegreeYear);
                    selectedYear.SelectByValue(degreeYear);
                }

                //Click action
                wait(30);
                if (action == "Save")
                    SaveEducationBtn.Click();
                else
                    CancelEducationBtn.Click();
            }
            wait(30);
            WaitToBeVisible(driver, "XPath", "//div[@class=\"ns-box-inner\"]", 50);
            notificationMessage = NotificationMesssage.Text;
        }

        public void EditEducation(string university, string country, string title, string degree, string degreeYear, string action)
        {
            //Click Education Tab
            wait(30);
            EducationTab.Click();

            wait(30);
            //Click Edit Education button (first row)
            EducationToUpdate.Click();

            wait(30);
            //Clear the University Name
            EnterUniversityName.Clear();

            wait(30);
            //Enter the University
            EnterUniversityName.SendKeys(university);

            if (country != "")
            {
                //Choose Country
                Wait.WaitToBeClickable("XPath", "(//SELECT[@class='ui fluid dropdown'])[1]", 100);
                ChooseCountryBtn.Click();
                wait(500);
                SelectElement selectedCountry = new SelectElement(ChooseCountryBtn);
                selectedCountry.SelectByValue(country);
            }

            if (title != "")
            {
                //Choose Title
                wait(30);
                ChooseTitleBtn.Click();
                wait(50);
                SelectElement selectedTitle = new SelectElement(ChooseTitleBtn);
                selectedTitle.SelectByValue(title);
            }
            //Clear the Degree Value
            wait(30);
            Degree.Clear();

            //Enter Degree
            wait(30);
            Degree.SendKeys(degree);

            if (degreeYear != "")
            {
                //Year of Graduation
                wait(30);
                DegreeYear.Click();
                wait(30);
                SelectElement selectedYear = new SelectElement(DegreeYear);
                selectedYear.SelectByValue(degreeYear);
            }

            //Click action
            wait(30);
            if (action == "Save")
                SaveEducationBtn.Click();
            else
                CancelEducationBtn.Click();

            wait(30);
            WaitToBeVisible(driver, "XPath", "//div[@class=\"ns-box-inner\"]", 50);
            notificationMessage = NotificationMesssage.Text;
        }

        public void DeleteEducation()
        {
            //Click Education Tab
            wait(30);
            EducationTab.Click();

            //Click Delete Skill button (first row)
            wait(30);
            EducationToDelete.Click();

            wait(30);
            WaitToBeVisible(driver, "XPath", "//div[@class=\"ns-box-inner\"]", 50);
            notificationMessage = NotificationMesssage.Text;
        }

        public void ValidateAddEducationResult(string message, ExtentTest test)
        {
            if ((message.Contains("Education has been added")) ||
            (message == "This information is already exist.") ||
            (message == "Duplicated data") ||
            (message.Contains("Please enter all the fields")))
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

        public void ValidateEditEducationResult(string message, ExtentTest test)
        {
            if ((message.Contains("Education as been updated")) ||
            (message == "This information is already exist.") ||
            (message == "Duplicated data") ||
            (message == "There is an error when updating education") ||
            (message.Contains("Please enter all the fields")))
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


        public void ValidateDeleteEducation(string message, ExtentTest test)
        {            
            if (message.Contains("Education entry successfully removed"))
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
