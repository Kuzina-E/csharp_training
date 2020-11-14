using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: AuthTestBase
    {
        [Test]
        public void RemoveContactTest()
        {
            app.Contacts.CheckContactIsPresent(1);

            List<ContactData> oldContacts = app.Contacts.GetContactList();


            app.Contacts.Remove(0);
            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
