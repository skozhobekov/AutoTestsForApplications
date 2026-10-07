using Microsoft.Playwright;

namespace apitest.UI.Pages;

public class OverviewPage
{
    private readonly IPage Page;

    private ILocator FinishButton => Page.Locator("#finish");
    private ILocator FinalPageText => Page.Locator(".complete-header");

    public OverviewPage(IPage page)
    {
        Page = page;
    }

    public async Task CheckProduct(string productName)
    {
        var product = Page
            .Locator(".cart_item")
            .Filter(new LocatorFilterOptions
            {
                HasText = productName
            });

        await Assertions.Expect(product).ToBeVisibleAsync();
    }

    public async Task Finish()
    {
        await FinishButton.ClickAsync();
    }

    public async Task CheckOrderComplete()
    {
        await Assertions.Expect(FinalPageText)
            .ToHaveTextAsync("Thank you for your order!");
    }
}