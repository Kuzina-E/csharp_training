using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture] 
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTestes()
        {
            GroupData group = new GroupData("aaa");
            group.Heder = "ddd";
            group.Footer = "sss";

            app.Groups.Create(group);
            app.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTestes()
        {
            GroupData group = new GroupData("");
            group.Heder = "";
            group.Footer = "";

            app.Groups.Create(group);
            app.Auth.Logout();
        }
    }
}
