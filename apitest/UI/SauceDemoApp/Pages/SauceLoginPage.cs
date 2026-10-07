using apitest.UI.Models;
using Microsoft.Playwright;

namespace apitest.UI.Pages;

public class SauceLoginPage
    
{
    private readonly IPage Page;
    private ILocator UserName => Page.Locator("#user-name");
    private ILocator PassWord => Page.Locator("#password");
    private ILocator LoginButton => Page.Locator("#login-button");
    
    private ILocator SuccessfulAuthCheckText => Page.Locator(".title");
    

    
    public SauceLoginPage(IPage page)
    {
        Page = page;
    }

    
    public async Task Submit()
    {
        await LoginButton.ClickAsync();
    }    
    public async Task FulFillFields(UserLoginFormModel userData)
    {
        await UserName.FillAsync(userData.UserName);
        await PassWord.FillAsync(userData.Password);
        
    }

    public async Task CheckAuth()
    {
        var actualText = await SuccessfulAuthCheckText.InnerTextAsync();
        Assert.That(actualText, Is.EqualTo("Products"));
        
    }
}