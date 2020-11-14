using System;
using System.Collections.Generic;
using OpenQA.Selenium;
namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
       

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Remove(int v)
        {
                SelectContact(v);
                RemoveContact();

                return this;
        }

        public List<ContactData> GetContactList()
        {

            List<ContactData> contacts = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    var info = element.FindElements(By.CssSelector("td"));
                    var contact = new ContactData(info[2].Text, info[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    };
                contacts.Add(contact);
                }

          return contacts;

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
               
            return this;
        }
      

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
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
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
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
        
    }
}
