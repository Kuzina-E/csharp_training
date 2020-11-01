using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests 
{
 
        [TestFixture]
        public class ContactCreationTests :  AuthTestBase
    {
  
            [Test]
            public void ContactCreateTests()
        {
            ContactData contact = new ContactData("Ivan", "Ivanov");

            app.Contacts.Create(contact);
            app.Auth.Logout();
        }
     }
    
    
}
