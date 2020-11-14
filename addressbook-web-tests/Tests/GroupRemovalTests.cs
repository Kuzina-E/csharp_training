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
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());


            List<GroupData> newGroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}

