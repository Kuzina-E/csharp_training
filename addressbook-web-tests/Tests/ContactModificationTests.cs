using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {


        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Petr", "Petrov");
            app.Contacts.Modify(1, newData);
        }
    }
}
