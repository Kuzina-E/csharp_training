using NUnit.Framework;


namespace WebAddressbookTests
{
    public class GroupRemovalTests : TestBase
    {
            [Test]
            public void TheDeleteGroupTest()
        {
            app.Groups.Remove(1);
        
        }
    }
}

