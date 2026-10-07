namespace apitest.Hooks.GroupTests;



[TestFixture]
public class CalculatorTests
{

    
    [TestCase(1,2,3)]
    [TestCase(-12,13,1)]
    public void AddTest(int a, int b, int result)
    {
        int res = Calculator.Add(a, b);
        Assert.That(res, Is.EqualTo(result),
            $"Expected {result}, but was {res}, a= {a}, b= {b}");

    }    
}