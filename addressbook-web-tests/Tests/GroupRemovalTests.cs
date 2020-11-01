using NUnit.Framework;


namespace WebAddressbookTests
{
    public class GroupRemovalTests : AuthTestBase
    {
            [Test]
            public void TheDeleteGroupTest()
        {
            app.Groups.Remove(1);
        
        }
    }
}

