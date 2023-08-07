using OpenQA.Selenium;
using static MarsFrameworkSpecflow.Global.GlobalDefinitions;
using MarsFrameworkSpecflow.Global;

namespace MarsFrameworkSpecflow.Pages
{
    public class ReceivedRequestPage : Base
    {
        IWebElement manageRequestsDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]"));
        IWebElement receivedRequestPage => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]/div/a[1]"));
        IWebElement showRequestDetails => driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[last()]/td[1]"));
        IWebElement starRating => driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[last()]/td[3]/div/i[5]"));
        IWebElement acceptRequest => driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]"));
        IWebElement declineRequest => driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[2]"));
        IWebElement getStatus => driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[5]"));
        IWebElement serviceTitle => driver.FindElement(By.XPath("//*[@class=\"skill-title\"]"));
        IWebElement requestTitle => driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[2]"));
        IWebElement serviceDetail => driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[2]/a"));
        IWebElement senderProfile => driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[4]"));
        IWebElement sortByCategory => driver.FindElement(By.XPath("//*[@class=\"two wide\" and contains(text(), \"Category\")]"));
        IWebElement sortByTitle => driver.FindElement(By.XPath("//*[@class=\"three wide\" and contains(text(), \"Title\")]"));
        IWebElement sortByMessage => driver.FindElement(By.XPath("//*[@class=\"four wide\" and contains(text(), \"Message\")]"));
        IWebElement sortBySender => driver.FindElement(By.XPath("//*[@class=\"one wide\" and contains(text(), \"Sender\")]"));
        IWebElement sortByStatus => driver.FindElement(By.XPath("//*[@class=\"two wide\" and contains(text(), \"Status\")]"));
        IWebElement sortByType => driver.FindElement(By.XPath("//*[@class=\"one wide\" and contains(text(), \"Type\")]"));
        IWebElement sortByDate => driver.FindElement(By.XPath("//*/div[2]/div[1]/table/thead/tr/th[7]"));
        IWebElement viewRequestedTitle => driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[2]/a"));
        IWebElement senderDetails => driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[4]"));
        IWebElement senderURL => driver.FindElement(By.XPath("//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[4]/a"));

        List<IWebElement> categoryList => new List<IWebElement>(driver.FindElements(By.XPath("//*/div[2]/div[1]/table/tbody/tr/td[1]")));
        List<IWebElement> titleList => new List<IWebElement>(driver.FindElements(By.XPath("//*/div[2]/div[1]/table/tbody/tr/td[2]")));
        List<IWebElement> messageList => new List<IWebElement>(driver.FindElements(By.XPath("//*/div[2]/div[1]/table/tbody/tr/td[3]")));
        List<IWebElement> senderList => new List<IWebElement>(driver.FindElements(By.XPath("//*/div[2]/div[1]/table/tbody/tr/td[4]")));
        List<IWebElement> statusList => new List<IWebElement>(driver.FindElements(By.XPath("//*/div[2]/div[1]/table/tbody/tr/td[5]")));
        List<IWebElement> typeList => new List<IWebElement>(driver.FindElements(By.XPath("//*/div[2]/div[1]/table/tbody/tr/td[6]")));
        List<IWebElement> dateList => new List<IWebElement>(driver.FindElements(By.XPath("//*/div[2]/div[1]/table/tbody/tr/td[7]")));


        public void ReceivedRequestsPage()
        {
            Wait.WaitToBeClickable("XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]", 5);
            manageRequestsDropdown.Click();
            Wait.WaitToBeClickable("XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/div[1]/div/a[1]", 5);
            receivedRequestPage.Click();
        }

        public void RequestDetailAndRating()
        {
            showRequestDetails.Click();
            starRating.Click();
            showRequestDetails.Click();
        }

        public void AcceptRequest()
        {
            Wait.WaitToBeVisible("XPath", "//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]", 5);
            acceptRequest.Click();
        }

        public void DeclineRequest()
        {
            Wait.WaitToBeVisible("XPath", "//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[2]", 5);
            declineRequest.Click();
        }

        public string GetStatus()
        {
            Task.Delay(3000).Wait();
            return getStatus.Text;
        }

        public string RequestsTitle()
        {
            Wait.WaitToBeClickable("XPath", "//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[2]", 5);
            return requestTitle.Text;
        }

        public void ViewServiceDetail()
        {
            Wait.WaitToBeClickable("XPath", "//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[2]/a", 5);
            serviceDetail.Click();
        }

        public string ServiceDetailTitle()
        {
            Wait.WaitToBeClickable("XPath", "//*[@class=\"skill-title\"]", 5);
            return serviceTitle.Text;
        }

        public void ViewSenderProfile()
        {
            Wait.WaitToBeClickable("XPath", "//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[4]", 5);
            senderProfile.Click();
        }

        public string GetSenderURL()
        {
            Wait.WaitToBeClickable("XPath", "//*[@id=\"received-request-section\"]/div[2]/div[1]/table/tbody/tr[1]/td[4]/a", 5);
            string urlSender = senderURL.GetAttribute("href").Substring(21);
            return urlSender;
        }

        public string GetPageURL()
        {
            string currentURL = driver.Url;
            string senderID = currentURL.Substring(21);
            return senderID;

        }
        // Sort by Category
        public void SortByCategory()
        {
            Wait.WaitToBeClickable("XPath", "//*[@class=\"two wide\" and contains(text(), \"Category\")]", 5);
            sortByCategory.Click();
        }

        public List<string> BeforeSortingCategory()
        {
            Wait.WaitToBeClickable("XPath", "//*/div[2]/div[1]/table/tbody/tr/td[1]", 5);
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

        // Sort by Sender
        public void SortBySender()
        {
            Wait.WaitToBeClickable("XPath", "//*[@class=\"one wide\" and contains(text(), \"Sender\")]", 5);
            sortBySender.Click();
        }

        public List<string> BeforeSortingSender()
        {
            Wait.WaitToBeVisible("XPath", "//*/div[2]/div[1]/table/tbody/tr/td[4]", 5);
            List<string> actualSenderList = new List<string>();

            foreach (IWebElement senderItem in senderList)
            {
                actualSenderList.Add(senderItem.Text);
            }
            Console.WriteLine(string.Join(" | ", actualSenderList));
            return actualSenderList;
        }

        public List<string> AfterSortingSender()
        {
            List<string> sortedSenderList = new List<string>();

            foreach (IWebElement senderItem in senderList)
            {
                sortedSenderList.Add(senderItem.Text);
                sortedSenderList.Sort();
            }
            Console.WriteLine(string.Join(" | ", sortedSenderList));
            return sortedSenderList;
        }

        // Sort by Status
        public void SortByStatus()
        {
            Wait.WaitToBeClickable("XPath", "//*[@class=\"two wide\" and contains(text(), \"Status\")]", 5);
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

        public void ViewRequestedTitle()
        {
            viewRequestedTitle.Click();
        }

        public void ViewRequesterDetails()
        {
            senderDetails.Click();

        }

    }
}
