using Microsoft.Playwright;

namespace apitest.UI.Pages;

public class MainPage
{
    private readonly IPage Page;

    private ILocator AddFirstThingToCardButton => Page.Locator("#add-to-cart-sauce-labs-backpack");
    private ILocator AddSecondThingToCardButton => Page.Locator("#add-to-cart-sauce-labs-bolt-t-shirt");
    private ILocator CardButton => Page.Locator(".shopping_cart_link");
    private ILocator CardPageText => Page.Locator(".title");



    public MainPage(IPage page)
    {
        Page = page;

    }

    public async Task AddProductToCart(string productName)
    {
        var product = Page
            .Locator(".inventory_item")
            .Filter(new LocatorFilterOptions
            {
                HasText = productName
            });

        await product
            .GetByRole(AriaRole.Button, new() { Name = "Add to cart" })
            .ClickAsync();
    }

    public async Task GoToCart()
    {
        await CardButton.ClickAsync();
    }
    
    public async Task CheckProductInCart(string productName)
    {
        var product = Page
            .Locator(".cart_item")
            .Filter(new LocatorFilterOptions
            {
                HasText = productName
            });

        await Assertions.Expect(product).ToBeVisibleAsync();
    }

}