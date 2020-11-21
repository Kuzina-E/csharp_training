using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {

          ContactData fromTable =  app.Contacts.GetComtactInformationFromTable(0);
          ContactData fromEditForm = app.Contacts.GetComtactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromEditForm);
            Assert.AreEqual(fromTable.Address, fromEditForm.Address);


            Assert.AreEqual(fromTable.AllPhones, fromEditForm.AllPhones);


        }
    }
}
