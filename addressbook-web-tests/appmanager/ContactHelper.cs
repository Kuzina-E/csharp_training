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
            manager.Navigator.OpenHomePage();
            return this;
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

            return new ContactData(firstname, lastname)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
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
            string allPhones = cells[5].Text;


            return new ContactData(firstname, lastname)
            {
                Address = address,
               AllPhones = allPhones
            };


        }

        private List<ContactData> contactCache = null;

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
        
    }
}
