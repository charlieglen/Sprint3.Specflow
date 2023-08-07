using OpenQA.Selenium;
using static MarsFrameworkSpecflow.Global.GlobalDefinitions;
using MarsFrameworkSpecflow.Global;

namespace MarsFrameworkSpecflow.Pages
{
    public class SentRequestPage : Base
    {
        IWebElement manageRequestsDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]"));
        IWebElement sentRequestPage => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]/div/a[2]"));
        IWebElement withdrawRequest => driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button"));
        IWebElement serviceTitle => driver.FindElement(By.XPath("//*[@class=\"skill-title\"]"));
        IWebElement sentRequestTitle => driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[2]"));
        IWebElement sentServiceDetail => driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[2]/a"));
        IWebElement sortByCategory => driver.FindElement(By.XPath("//*[@class=\"two wide\" and contains(text(), \"Category\")]"));
        IWebElement sortByTitle => driver.FindElement(By.XPath("//*[@class=\"three wide\" and contains(text(), \"Title\")]"));
        IWebElement sortByMessage => driver.FindElement(By.XPath("//*[@class=\"four wide\" and contains(text(), \"Message\")]"));
        IWebElement sortByRecepient => driver.FindElement(By.XPath("//*[@class=\"two wide\" and contains(text(), \"Recipient\")]"));
        IWebElement sortByStatus => driver.FindElement(By.XPath("//*[@class=\"one wide\" and contains(text(), \"Status\")]"));
        IWebElement sortByType => driver.FindElement(By.XPath("//*[@class=\"one wide\" and contains(text(), \"Type\")]"));
        IWebElement sortByDate => driver.FindElement(By.XPath("//*/div[2]/div[1]/table/thead/tr/th[7]"));
        IWebElement recipientProfile => driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[4]/a"));
        IWebElement recipientURL => driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[4]/a"));
        IWebElement getStatus => driver.FindElement(By.XPath("//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[5]"));

        List<IWebElement> categoryList => new List<IWebElement>(driver.FindElements(By.XPath("//*/div[2]/div[1]/table/tbody/tr/td[1]")));
        List<IWebElement> titleList => new List<IWebElement>(driver.FindElements(By.XPath("//*/div[2]/div[1]/table/tbody/tr/td[2]")));
        List<IWebElement> messageList => new List<IWebElement>(driver.FindElements(By.XPath("//*/div[2]/div[1]/table/tbody/tr/td[3]")));
        List<IWebElement> statusList => new List<IWebElement>(driver.FindElements(By.XPath("//*/div[2]/div[1]/table/tbody/tr/td[5]")));
        List<IWebElement> typeList => new List<IWebElement>(driver.FindElements(By.XPath("//*/div[2]/div[1]/table/tbody/tr/td[6]")));
        List<IWebElement> dateList => new List<IWebElement>(driver.FindElements(By.XPath("//*/div[2]/div[1]/table/tbody/tr/td[7]")));
        List<IWebElement> recepientList => new List<IWebElement>(driver.FindElements(By.XPath("//*/div[2]/div[1]/table/tbody/tr/td[4]")));


        public void SentRequestsPage()
        {
            Wait.WaitToBeClickable("XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]", 5);
            manageRequestsDropdown.Click();
            Wait.WaitToBeClickable("XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]/div/a[2]", 5);
            sentRequestPage.Click();
        }
        public void WithdrawRequest()
        {
            Wait.WaitToBeClickable("XPath", "//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button", 5);
            withdrawRequest.Click();
        }

        public string GetStatus()
        {
            Task.Delay(3000).Wait();
            return getStatus.Text;
        }

        public void ViewSentServiceDetail()
        {
            Wait.WaitToBeClickable("XPath", "//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[2]/a", 5);
            sentServiceDetail.Click();
        }

        public string SentRequestTitle()
        {
            Wait.WaitToBeClickable("XPath", "//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[2]", 5);
            return sentRequestTitle.Text;
        }

        public string ServiceDetailTitle()
        {
            Wait.WaitToBeClickable("XPath", "//*[@class=\"skill-title\"]", 5);
            return serviceTitle.Text;
        }

        public void ViewRecipientsProfile()
        {
            Wait.WaitToBeClickable("XPath", "//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[4]/a", 5);
            recipientProfile.Click();
        }

        public string GetRecipientURL()
        {
            Wait.WaitToBeClickable("XPath", "//*[@id=\"sent-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[4]/a", 5);
            string urlRecipient = recipientURL.GetAttribute("href").Substring(21);
            return urlRecipient;
        }

        public string GetPageURL()
        {
            string currentURL = driver.Url;
            string recepientID = currentURL.Substring(21);
            return recepientID;
        }
        // Sort by Category
        public void SortByCategory()
        {
            Wait.WaitToBeClickable("XPath", "//*[@class=\"two wide\" and contains(text(), \"Category\")]", 5);
            sortByCategory.Click();
        }

        public List<string> BeforeSortingCategory()
        {
            Wait.WaitToBeClickable("XPath", "//div[2]/div[1]/table/tbody/tr/td[1]", 5);
            List<string> actualCategoryList = new List<string>();

            foreach (IWebElement categoryItem in categoryList)
            {
                actualCategoryList.Add(categoryItem.Text);
            }
            Console.WriteLine(string.Join(" | ", actualCategoryList));
            return actualCategoryList;
        }

        public List<string> AfterSortingCategory()
        {
            List<string> sortedCategoryList = new List<string>();

            foreach (IWebElement categoryItem in categoryList)
            {

                sortedCategoryList.Add(categoryItem.Text);
                sortedCategoryList.Sort();
            }
            Console.WriteLine(string.Join(" | ", sortedCategoryList));
            return sortedCategoryList;
        }

        // Sort by Title
        public void SortByTitle()
        {
            Wait.WaitToBeClickable("XPath", "//*[@class=\"three wide\" and contains(text(), \"Title\")]", 5);
            sortByTitle.Click();
        }

        public List<string> BeforeSortingTitle()
        {
            Wait.WaitToBeVisible("XPath", "//*/div[2]/div[1]/table/tbody/tr/td[2]", 5);
            List<string> actualTitleList = new List<string>();

            foreach (IWebElement titleItem in titleList)
            {
                actualTitleList.Add(titleItem.Text);
            }
            Console.WriteLine(string.Join(" | ", actualTitleList));
            return actualTitleList;
        }

        public List<string> AfterSortingTitle()
        {
            List<string> sortedTitleList = new List<string>();

            foreach (IWebElement titleItem in titleList)
            {
                sortedTitleList.Add(titleItem.Text);
                sortedTitleList.Sort();
            }
            Console.WriteLine(string.Join(" | ", sortedTitleList));
            return sortedTitleList;
        }

        // Sort by Message
        public void SortByMessage()
        {
            Wait.WaitToBeClickable("XPath", "//*[@class=\"four wide\" and contains(text(), \"Message\")]", 5);
            sortByMessage.Click();
        }

        public List<string> BeforeSortingMessage()
        {
            Wait.WaitToBeVisible("XPath", "//*/div[2]/div[1]/table/tbody/tr/td[3]", 5);
            List<string> actualMessageList = new List<string>();

            foreach (IWebElement messageItem in messageList)
            {
                actualMessageList.Add(messageItem.Text);
            }
            Console.WriteLine(string.Join(" | ", actualMessageList));
            return actualMessageList;
        }
        public List<string> AfterSortingMessage()
        {
            List<string> sortedMessageList = new List<string>();

            foreach (IWebElement messageItem in messageList)
            {
                sortedMessageList.Add(messageItem.Text);
                sortedMessageList.Sort();
            }
            Console.WriteLine(string.Join(" | ", sortedMessageList));
            return sortedMessageList;
        }

        // Sort by Recepient
        public void SortByRecepient()
        {
            Wait.WaitToBeClickable("XPath", "//*[@class=\"two wide\" and contains(text(), \"Recipient\")]", 5);
            sortByRecepient.Click();
        }

        public List<string> BeforeSortingRecepient()
        {
            Wait.WaitToBeClickable("XPath", "//*/div[2]/div[1]/table/tbody/tr/td[4]", 5);
            List<string> actualRecepientList = new List<string>();

            foreach (IWebElement senderItem in recepientList)
            {
                actualRecepientList.Add(senderItem.Text);
            }
            Console.WriteLine(string.Join(" | ", actualRecepientList));
            return actualRecepientList;
        }

        public List<string> AfterSortingRecepient()
        {
            List<string> sortedRecepientList = new List<string>();

            foreach (IWebElement senderItem in recepientList)
            {
                sortedRecepientList.Add(senderItem.Text);
                sortedRecepientList.Sort();
            }
            Console.WriteLine(string.Join(" | ", sortedRecepientList));
            return sortedRecepientList;
        }

        // Sort by Status
        public void SortByStatus()
        {
            Wait.WaitToBeClickable("XPath", "//*[@class=\"one wide\" and contains(text(), \"Status\")]", 5);
            sortByStatus.Click();
        }

        public List<string> BeforeSortingStatus()
        {
            Wait.WaitToBeClickable("XPath", "//*/div[2]/div[1]/table/tbody/tr/td[5]", 5);
            List<string> actualStatusList = new List<string>();

            foreach (IWebElement statusItem in statusList)
            {
                actualStatusList.Add(statusItem.Text);
            }
            Console.WriteLine(string.Join(" | ", actualStatusList));
            return actualStatusList;
        }

        public List<string> AfterSortingStatus()
        {
            List<string> sortedStatusList = new List<string>();


            foreach (IWebElement statusItem in statusList)
            {
                sortedStatusList.Sort();
            }

            Console.WriteLine(string.Join(" | ", sortedStatusList));
            return sortedStatusList;
        }

        // Sort by Type
        public void SortByType()
        {
            Wait.WaitToBeClickable("XPath", "//*[@class=\"one wide\" and contains(text(), \"Type\")]", 5);
            sortByType.Click();
        }

        public List<string> BeforeSortingType()
        {
            Wait.WaitToBeClickable("XPath", "//*/div[2]/div[1]/table/tbody/tr/td[6]", 5);
            List<string> actualTypeList = new List<string>();

            foreach (IWebElement typeItem in typeList)
            {
                actualTypeList.Add(typeItem.Text);
            }
            Console.WriteLine(string.Join(" | ", actualTypeList));
            return actualTypeList;
        }

        public List<string> AfterSortingType()
        {
            List<string> sortedTypeList = new List<string>();

            foreach (IWebElement typeItem in typeList)
            {
                sortedTypeList.Add(typeItem.Text);
                sortedTypeList.Sort();
            }
            Console.WriteLine(string.Join(" | ", sortedTypeList));
            return sortedTypeList;
        }

        // Sort by Date
        public void SortByDate()
        {
            Wait.WaitToBeClickable("XPath", "//*/div[2]/div[1]/table/thead/tr/th[7]", 5);
            sortByDate.Click();
        }

        public List<string> BeforeSortingDate()
        {
            Wait.WaitToBeClickable("XPath", "//*/div[2]/div[1]/table/tbody/tr/td[7]", 5);
            List<string> actualDateList = new List<string>();

            foreach (IWebElement dateItem in dateList)
            {
                actualDateList.Add(dateItem.Text);
            }
            Console.WriteLine(string.Join(" | ", actualDateList));
            return actualDateList;
        }

        public List<string> AfterSortingDate()
        {
            List<string> sortedDateList = new List<string>();

            foreach (IWebElement dateItem in dateList)
            {
                sortedDateList.Add(dateItem.Text);
                sortedDateList.Sort();
            }
            Console.WriteLine(string.Join(" | ", sortedDateList));
            return sortedDateList;
        }

    }
}
