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
            app.Contacts.Remove(1);

        }
    }
}
