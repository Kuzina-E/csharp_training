using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class GroupRemovalTests : AuthTestBase
    {
            [Test]
            public void TheDeleteGroupTest()
        {
            app.Groups.CheckGroupIsPresent(1);

            List<GroupData> oldGroups = app.Groups.GetGroupList();


            app.Groups.Remove(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

