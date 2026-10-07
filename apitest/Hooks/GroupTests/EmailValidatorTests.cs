
using apitest.Hooks.DataProvider;

namespace apitest.Hooks.GroupTests;


[TestFixture]
public class EmailValidatorTests
{
    [TestCaseSource(typeof(EmailTestDataProvider), nameof(EmailTestDataProvider.GetEmailCases))]
    public void EmailValidationTest(string email, bool result)
    {
        bool res = Validator.IsValid(email);
        Assert.That(res, Is.EqualTo(result), 
            $"email {email} did not validated. Expected {result}, yet actual {res}");
        
    }
}