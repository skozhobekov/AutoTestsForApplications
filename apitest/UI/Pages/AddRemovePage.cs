using Microsoft.Playwright;

namespace apitest.UI.Pages;

public class AddRemovePage
{
    private readonly IPage Page;
    
    private ILocator addButton => Page.GetByRole(AriaRole.Button, new() { Name = $"(textFromButton)" });
    private ILocator deleteButtons => Page.GetByRole(AriaRole.Button, new () { Name = $"(button.added-manually)" });
    
    
    
    public AddRemovePage(IPage page)
    {
        Page = page;
    }

    public async Task OpenAddRemovePageAsync()
    {
        await Page.GotoAsync("https://the-internet.herokuapp.com/add_remove_elements/");
    }

    public async Task ClickButtonByNameAndNumberAsync()
    {
        
   
    }
}