namespace apitest.Retries;

[TestFixture]
public class RetryTests
{
    [Test]
    public void SimpleRetryTest()
    {
        RetryHelper.Operation method = AdditionalMethod.RandomSuccess;
        RetryHelper.Retry(method, 10);
    }

    [Test]
    public void SimpleRetryWithReturnTest()
    {
        RetryHelper.Operation method = AdditionalMethod.RandomSuccess;
        var result = RetryHelper.RetryUntilTrue(method, 10);
        Assert.That(result, Is.True);
    }

    [Test]
    public void SimpleRetryWithTimeOutTest()
    {
        RetryHelper.Operation method = AdditionalMethod.RandomSuccess;
        RetryHelper.RetryWithTimeOutsAndPauses(method, 30000, 3000);
    }
    
     [Test]
     public void SimpleRetryWithTimeOutAndReturnTest()
     {
         RetryHelper.Operation method = AdditionalMethod.RandomSuccess;
         RetryHelper.RetryWithTimeOutsAndPauses(method, 50000, 5000);
         
     }
    
    [Test]
    public void SimpleRetryWithPollyTest()
    {
        RetryWithPollyHelper.Operation method = AdditionalMethod.RandomSuccess;
        RetryWithPollyHelper.RetryWithPolly(method, 30000, 3000);
    }
}

