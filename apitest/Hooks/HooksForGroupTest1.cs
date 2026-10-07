namespace apitest.Hooks;

public class HooksForGroupTest1
{
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        Console.WriteLine("выполняется перед стартом всех тестов группы 1");
    }

    [SetUp]
    public void Setup()
    {
        Console.WriteLine("выполняется перед каждым тестом из группы 1");
    }

    [TearDown]
    public void TearDown()
    {
        Console.WriteLine("выполняется после каждого теста из группы 1");
        
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Console.WriteLine("выполняется один раз после окончания прохождения всех тестов группы 1");
    }
}