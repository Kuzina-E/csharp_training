using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RemovingContactFromGroupTests : AuthTestBase
    {

        [Test]
        public void TestRemoveContactFromGroup()
        {
            if (GroupData.GetAll().Count == 0)
            {
                app.Groups.Create(new GroupData("aaa", "sss", "ddd"));
            }

            List<GroupData> groups = GroupData.GetAll();

            for (int i = 0; i < groups.Count(); i++)
            {
                GroupData group = groups[i];
 
                if (ContactData.GetAll().Count == 0)

                {
                    app.Contacts.Create(new ContactData("aaa", "aaa"));

                    ContactData createdContact = ContactData.GetAll().First();

                    app.Contacts.AddContactToGroup(createdContact, group);
                }
      
                if (group.GetContacts().Count() == 0)
                {
                    app.Contacts.AddContactToGroup(ContactData.GetAll()[0], group);
                }

                List<ContactData> oldList = group.GetContacts();

                ContactData contactToRemove = oldList[0];

                app.Contacts.RemoveContactFromGroup(contactToRemove, group);

                List<ContactData> newList = group.GetContacts();

                oldList.Remove(contactToRemove);

                newList.Sort();
                oldList.Sort();

                Assert.AreEqual(oldList, newList);
            }
        }




    }
}
