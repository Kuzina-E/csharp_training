using System;
using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
     
        protected string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            :base(manager)
        {
            this.baseURL = baseURL;
        }

        internal void GoToContactsPage()
        {
            if (driver.Url == baseURL + "/addressbook/edit.php"
               && IsElementPresent(By.Name("submit")))
            {
                return;
            }
                driver.FindElement(By.LinkText("add new")).Click();
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/")

            {
                return;

            }
                driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }


            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}
