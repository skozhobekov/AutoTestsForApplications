using Microsoft.Playwright;

namespace apitest.UI.Pages;

public class DropDownPage
{
    private readonly IPage Page;
    private ILocator  DropDown => Page.Locator("#dropdown"); 
    private ILocator selected1 => Page.Locator("option:checked");
    private Task<string> text => selected1.InnerTextAsync();

    public DropDownPage(IPage page)
    {
        Page = page;   
    }

    public async Task DropDownClick()
    {
        
    }
}