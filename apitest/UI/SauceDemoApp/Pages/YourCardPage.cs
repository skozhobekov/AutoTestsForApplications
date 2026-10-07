using Microsoft.Playwright;

namespace apitest.UI.Pages;

public class YourCartPage
{
    private readonly IPage Page;
    
     

    private ILocator CardButton => Page.Locator("#checkout");

    public YourCartPage(IPage page)
    {
        Page = page;
    }
    
    public async Task CheckProduct(string productName) 
    { 
        var product = Page .Locator(".cart_item").
            Filter(new LocatorFilterOptions { HasText = productName }); 
        await Assertions.Expect(product).ToBeVisibleAsync(); }

    public async Task CheckoutButtonClick()
    {
        await CardButton.ClickAsync();
    }

}