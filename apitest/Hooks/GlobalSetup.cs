namespace apitest.Hooks;


[SetUpFixture]
public class GlobalSetup
{
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        Console.WriteLine("one time setting prior to all tests");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Console.WriteLine("one time setting done after all tests");
    }
}