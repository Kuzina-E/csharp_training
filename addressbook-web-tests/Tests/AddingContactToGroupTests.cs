using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact =  ContactData.GetAll().Except(oldList).First();

            for (int i = 0; i < oldList.Count(); i++)
            {
                if (oldList[i].Id.Equals(contact.Id))
                {
                    contact = new ContactData("aaa", "aaa");
                    app.Contacts.Create(contact);
                    contact.Id = app.Contacts.GetContactId();
                }
            }
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();

            oldList.Add(contact);

            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);

        }

    }
}
