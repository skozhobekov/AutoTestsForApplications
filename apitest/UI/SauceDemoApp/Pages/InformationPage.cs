using Microsoft.Playwright;

namespace apitest.UI.Pages;

public class InformationPage
{
    private readonly IPage Page;

    private ILocator FirstNameField => Page.Locator("#first-name");
    private ILocator LastNameField => Page.Locator("#last-name");
    private ILocator PostalCodeField => Page.Locator("#postal-code");
    private ILocator ContinueButton => Page.Locator("#continue");
    private ILocator FinishButton => Page.Locator("#finish");
    
    private ILocator FinalPageText => Page.Locator(".complete-header");

    public InformationPage(IPage page)
    {
        Page = page;
    }

    public async Task FillThreeFieldsAndContinue(string firstName, string lastName, string postalCode)
    {
        await FirstNameField.FillAsync(firstName);
        await LastNameField.FillAsync(lastName);
        await PostalCodeField.FillAsync(postalCode);
        await ContinueButton.ClickAsync();
        // await FinishButton.ClickAsync();
        // var finalPageText = await FinalPageText.InnerTextAsync();
        //Assert.That(finalPageText, Is.EqualTo("Thank you for your order!"));
    }
}
