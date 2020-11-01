using NUnit.Framework;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        

        [OneTimeSetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app  = ApplicationManager.GetInstance();
        }

      
    }
}
