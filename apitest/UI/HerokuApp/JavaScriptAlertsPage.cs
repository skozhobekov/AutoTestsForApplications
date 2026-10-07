using Microsoft.Playwright;

namespace apitest.UI;

public class JavaScriptAlertsPage
{
    private protected IPage Page;
    private ILocator JSAlertButton => Page.GetByRole(AriaRole.Button, new  () { Name = $"Click for JS Alert" });
    private ILocator ResultText => Page.Locator("#result");

    public JavaScriptAlertsPage(IPage page)
    {
        Page = page;
    }

    public async Task OpenAllertsPage()
    {
        await Page.GotoAsync("https://the-internet.herokuapp.com/javascript_alerts");
        
    }

    public async Task ClickJsAlertButtonAsync()
    {
        await JSAlertButton.ClickAsync();
    }

    public Task<string> GetResultTextAsync()
    {
        return null;
    }

    public async Task ClickJSPromtButtonAsync()
    {
        await JSAlertButton.ClickAsync();
    }
}