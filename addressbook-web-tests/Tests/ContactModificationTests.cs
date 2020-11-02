using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {


        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Petr", "Petrov");
            app.Contacts.CheckContactIsPresent(1);
            app.Contacts.Modify(1, newData);
        }
    }
}
