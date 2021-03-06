﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
       
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.OpenHomePage();

            SelectContact(v);
                RemoveContact();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(contact.Id);
            RemoveContact();
            manager.Navigator.OpenHomePage();
            return this;

        }

        public string GetContactId()
        {
            manager.Navigator.OpenHomePage();
            return driver.FindElements(By.XPath("//tr/td/input[@name='selected[]']")).Last().GetAttribute("value");
        }

        public ContactData GetComtactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactsModification(0);

            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email_1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email_2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email_3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                Email_1 = email_1,
                Email_2 = email_2,
                Email_3 = email_3,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }

        public string GetComtactInformationFromDetails(int index)
        {
            manager.Navigator.OpenHomePage();
            InitViewContactsDetails(index);

              string details = driver.FindElement(By.Id("content")).Text;

              return details;
        }

        public string CollectContactInfo(ContactData contact)
        {

            if (contact.FirstName != "" ||
                contact.LastName != "" ||
                contact.Address != "")
            {

            if (contact.FirstName != "" ||
                contact.LastName != "")

                {
                    info = info + System.String.Format(@"{0} {1}", contact.FirstName, contact.LastName);
                    info = Regex.Replace(info, "  ", " ");
                }
            }
            if (contact.Address != "")

                {
                    info = info + "\n" + contact.Address;
                }
         

            if (contact.HomePhone != "" ||
                contact.MobilePhone != "" ||
                contact.WorkPhone != "")
            {
                info = info + "\n";

                if (contact.HomePhone != "")
                {
                    info = info + "\nH: " + contact.HomePhone;
                }

                if (contact.MobilePhone != "")
                {
                   info = info + "\nM: " + contact.MobilePhone;
                 

                }

                if (contact.WorkPhone != "")
                {
                    info = info + "\nW: " + contact.WorkPhone;
                }
            }

            if (contact.Email_1 != "" || contact.Email_2 != "" || contact.Email_3 != "" )
            {
                info += "\n";

                if (contact.Email_1 != "")
                {
                    info += "\n" + contact.Email_1;
                }

                if (contact.Email_2 != "")
                {
                    info += "\n" + contact.Email_2;
                }

                if (contact.Email_3 != "")
                {
                    info += "\n" + contact.Email_3;
                }

            
            }
            info.Trim();
            info = Regex.Replace(info, "  ", " ");
            return info;
        }
        

        public void InitViewContactsDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                 .FindElements(By.TagName("td"))[6]
                 .FindElement(By.TagName("a")).Click();
        }

        public void InitContactsModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                 .FindElements(By.TagName("td"))[7]
                 .FindElement(By.TagName("a")).Click();
        }



        public ContactData GetComtactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();

            IList<IWebElement> cells =  driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));

            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;


            return new ContactData(firstname, lastname)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };


        }

        private List<ContactData> contactCache = null;
        private string info = null;

        public List<ContactData> GetContactList()
        {

            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
               
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    var info = element.FindElements(By.CssSelector("td"));
                    var contact = new ContactData(info[2].Text, info[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    };
                    contactCache.Add(contact);
                }

            }

            return new List<ContactData>(contactCache);

        }

        internal int GetContactCount()
        {
           return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
        }

        private bool ContactIsPresent()
         {
            return
                 IsElementPresent(By.Name("entry"));
        }


        public ContactHelper CheckContactIsPresent(int index)
        {
            if (ContactIsPresent())
            {
                return this;
            }
            else
            {
                ApplicationManager app = ApplicationManager.GetInstance();
                ContactData contact = new ContactData("1","1");
                app.Contacts.Create(contact);
                return this;
            }
        }
 
        public ContactHelper Modify(int v, ContactData newData)
        {
    
                SelectContact(v);

                InitContactModification();
                FillContactForm(newData);
                SubmitContactModification();
                ReturnToHomePage();
            return this;
        }
      

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//*[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;

            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper SelectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
            return this;

        }
        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;

            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.OpenHomePage();

            string text = driver.FindElement(By.TagName("label")).Text;

           Match m = new Regex(@"\d+").Match(text);
           return Int32.Parse(m.Value);
        }


        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);

            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);

        }

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            SelectGroupToRemove(group.Id);
            SelectContact(contact.Id);
            CommitDeleteContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void CommitDeleteContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);

        }

        private void SelectGroupToRemove(string id)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByValue(id);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }
    }
}
