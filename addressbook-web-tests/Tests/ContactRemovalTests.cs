using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: AuthTestBase
    {
        [Test]
        public void RemoveContactTest()
        {
            app.Contacts.Remove(1);

        }
    }
}
