using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: TestBase
    {
        [Test]
        public void RemoveContactTest()
        {
            app.Contacts.Remove(1);

        }
    }
}
