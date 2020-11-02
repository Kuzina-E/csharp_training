using System;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class GroupModificationTests: AuthTestBase
    {



        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Heder = null;
            newData.Footer = null;

            app.Groups.CheckGroupIsPresent(1);

            app.Groups.Modify(1, newData);
        }
    }
}
