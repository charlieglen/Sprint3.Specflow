using MarsFramework.Global;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using static MarsFramework.Global.GlobalDefinitions.ExcelLib;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.GlobalDefinitions.Wait;
using AventStack.ExtentReports;

namespace MarsFramework.Pages.ProfilePages
{
    public class ProfileCertificates : Base
    {
        public ProfileCertificates()
        {
            PopulateInCollection(ExcelPath, "Profile");
        }

        #region  Find Elements


        //Click on Certification Tab
        IWebElement CertificationsTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));

        //Click Add new Certification button
        IWebElement AddNewCertificationBtn => driver.FindElement(By.XPath("(//DIV[@class='ui teal button '][text()='Add New'])[3]"));

        //Enter Certificate Name
        IWebElement EnterCerticateName => driver.FindElement(By.XPath("(//INPUT[@type='text'])[4]"));

        //enter Certified from
        IWebElement CertifiedFrom => driver.FindElement(By.XPath("(//INPUT[@type='text'])[5]"));

        //Enter Year Certified
        static IWebElement YearCertified => driver.FindElement(By.XPath("//SELECT[@class='ui fluid dropdown']"));

        //Click Add Ceritification details
        IWebElement SaveCertificateBtn => driver.FindElement(By.XPath("(//INPUT[@type='button'])[1]"));

        //Click Cancel button to cancel new certification entry
        IWebElement CancelCertificateBtn => driver.FindElement(By.XPath("(//INPUT[@type='button'])[2]"));

        //First row in Certificates to Update
        IWebElement CertificateToUpdate => driver.FindElement(By.XPath("(//I[@class='outline write icon'])[8]"));

        //First row in Certificates to Delete
        IWebElement CertificateToDelete => driver.FindElement(By.XPath("(//I[@class='remove icon'])[7]"));

        //Notification Message
        IWebElement NotificationMesssage => driver.FindElement(By.XPath("//div[@class=\"ns-box-inner\"]"));

        #endregion

        private string notificationMessage = "";

        public string GetNotificationMessage()
        {
            return notificationMessage;
        }

        public void AddNewCertificate(string certName, string certFrom, string yearCert, string action)
        {
            //Click Certificate Tab
            wait(30);
            CertificationsTab.Click();

            if (AddNewCertificationBtn.Displayed)
            {
                //Add new Certificate button
                wait(30);
                AddNewCertificationBtn.Click();

                //Enter Certificate Name
                wait(30);
                EnterCerticateName.SendKeys(certName);

                //Enter Certified from
                wait(30);
                CertifiedFrom.SendKeys(certFrom);

                if (yearCert != "")
                {
                    //Enter the Year Certified
                    wait(30);
                    YearCertified.Click();
                    wait(30);
                    SelectElement selectedYear = new SelectElement(YearCertified);
                    selectedYear.SelectByValue(yearCert);
                }

                //Click action
                wait(50);
                if (action == "Save")
                    SaveCertificateBtn.Click();
                else
                    CancelCertificateBtn.Click();
            }
            wait(30);
            WaitToBeVisible(driver, "XPath", "//div[@class=\"ns-box-inner\"]", 50);
            notificationMessage = NotificationMesssage.Text;
        }

        public void EditCertificate(string certName, string certFrom, string yearCert, string action)
        {
            //Click Certificate Tab
            wait(30);
            CertificationsTab.Click();

            //Click Edit Certificate button (first row)
            wait(30);
            CertificateToUpdate.Click();

            wait(30);
            //Clear the Certificate Name Textbox
            EnterCerticateName.Clear();

            //Enter Certificate Name
            wait(30);
            EnterCerticateName.SendKeys(certName);

            wait(30);
            //Clear the Certificate From Textbox
            CertifiedFrom.Clear();

            //Enter Certified from
            wait(30);
            CertifiedFrom.SendKeys(certFrom);

            if (yearCert != "")
            {
                //Enter the Year Certified
                wait(30);
                YearCertified.Click();
                wait(30);
                SelectElement selectedYear = new SelectElement(YearCertified);
                selectedYear.SelectByValue(yearCert);
            }

            //Click action
            wait(50);
            if (action == "Save")
                SaveCertificateBtn.Click();
            else
                CancelCertificateBtn.Click();

            wait(30);
            WaitToBeVisible(driver, "XPath", "//div[@class=\"ns-box-inner\"]", 50);
            notificationMessage = NotificationMesssage.Text;
        }

        public void DeleteCertificate()
        {
            //Click Certificate Tab
            wait(30);
            CertificationsTab.Click();

            //Click Delete Certificate button (first row)
            wait(30);
            CertificateToDelete.Click();

            wait(30);
            WaitToBeVisible(driver, "XPath", "//div[@class=\"ns-box-inner\"]", 50);
            notificationMessage = NotificationMesssage.Text;
        }

        public void ValidateAddCertificateResult(string message, string certName, ExtentTest test)
        {
            if ((message == (certName + " has been added to your certification")) ||
            (message == "undefined") ||
            (message == "This information is already exist.") ||
            (message == "Duplicated data") ||
            (message == "Please enter Certification Name, Certification From and Certification Year"))
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
       
        public void ValidateEditCertificateResult(string message, string certName, ExtentTest test)
        {
            if ((message == (certName + " has been updated to your certification")) ||
            (message == "undefined") ||
            (message == "This information is already exist.") ||
            (message == "Duplicated data") ||
            (message == "Please enter Certification Name, Certification From and Certification Year"))
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

        public void ValidateDeleteCertificateResult(string message, ExtentTest test)
        {
            if (message.Contains("has been deleted from your certification"))
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
