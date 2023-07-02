using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsFrameworkSpecflow.Global;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFrameworkSpecflow.Pages

{
    public class LoginPage : Base
    {
        public LoginPage()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "LogIn");
        }
            IWebElement signinButton => driver.FindElement(By.CssSelector("[class=\"item\"]"));
            IWebElement emailTextbox => driver.FindElement(By.Name("email"));
            IWebElement passwordTextbox => driver.FindElement(By.Name("password"));
            IWebElement rememberMeCheckbox => driver.FindElement(By.Name("rememberDetails"));
            IWebElement loginButton => driver.FindElement(By.XPath("//*[contains(text(),'Login')]"));

        public void LogInActions()
        {
            signinButton.Click();
            emailTextbox.SendKeys(ExcelLib.ReadData(2, "UserEmail"));
            passwordTextbox.SendKeys(ExcelLib.ReadData(2, "Password"));
            rememberMeCheckbox.Click();
            loginButton.Click();
        }
    }
}
