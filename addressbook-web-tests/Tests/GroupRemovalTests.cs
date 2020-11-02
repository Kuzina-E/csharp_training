using NUnit.Framework;


namespace WebAddressbookTests
{
    public class GroupRemovalTests : AuthTestBase
    {
            [Test]
            public void TheDeleteGroupTest()
        {
            app.Groups.CheckGroupIsPresent(1);
            app.Groups.Remove(1);
        
        }
    }
}

