using System;
using System.Collections.Generic;
using OpenQA.Selenium;
namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
 
        protected string baseURL;

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();

            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));

            foreach(IWebElement element in elements)
            {
              
                groups.Add(new GroupData(element.Text));
            }

            return groups;
        }

        public GroupHelper Remove(int v)
        {

            manager.Navigator.GoToGroupsPage();

   
                SelectGroup(v);
                RemoveGroup();
                ReturnToGroupsPage();
                return this;
      
        }

       private bool GroupIsPresent()
        {
            return
                IsElementPresent(By.Name("selected[]"));
     
        }
        public GroupHelper CheckGroupIsPresent(int index)
        {
            manager.Navigator.GoToGroupsPage();

            if (GroupIsPresent())
            {
                return this;
            }
            else
            {
                ApplicationManager app = ApplicationManager.GetInstance();
                GroupData group = new GroupData("1");
                app.Groups.Create(group);
                return this;
            }
        }

       

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();


                SelectGroup(v);
                InitGroupModification();
                FillGroupForm(newData);
                SubmitGroupModification();
                return this;


        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;

        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;

        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();

            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();

            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
           

            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Heder);
            Type(By.Name("group_footer"), group.Footer);
        
            return this;
        }

        
    }
}
