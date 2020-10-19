using System;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class GroupModificationTests: TestBase
    {



        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Heder = "ttt";
            newData.Footer = "qqq";

            app.Groups.Modify(1, newData);
        }
    }
}
