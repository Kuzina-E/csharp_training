using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture] 
    public class GroupCreationTests : AuthTestBase
    {

        [Test]
        public void GroupCreationTestes()
        {
            GroupData group = new GroupData("aaa");
            group.Heder = "ddd";
            group.Footer = "sss";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            app.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTestes()
        {
            GroupData group = new GroupData("");
            group.Heder = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);


            app.Auth.Logout();
        }

        [Test]
        public void BadNameGroupCreationTestes()
        {
            GroupData group = new GroupData("a'a");
            group.Heder = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);


            app.Auth.Logout();
        }
    }
}
