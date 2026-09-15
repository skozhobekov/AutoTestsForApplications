using FluentAssertions;
using Microsoft.Playwright;

namespace apitest.UI;

public class HerokuTests : BaseTest
{
    [Test]
    public async Task FormAuthentication()
    {
        await Page.GotoAsync("https://the-internet.herokuapp.com/login");
        var userNameTextBox = Page.GetByRole(AriaRole.Textbox, new() { Name = "Username"});
        await userNameTextBox.FillAsync("wrong");
        var passTextBox = Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" });
        //var passTextBox = await Page.QuerySelectorAsync("#password");
        //var passTextBox = Page.Locator("#password");
        await passTextBox.FillAsync("wrong");
        var loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        await loginButton.ClickAsync();
        var errorMessageLabel = Page.Locator("//div[@id='flash']");
        var errorMessage = await errorMessageLabel.TextContentAsync();
        errorMessage.Should().Contain("Your username is invalid!");
    }
    

    [Test]
    public async Task DropDown()
    {
        await Page.GotoAsync("https://the-internet.herokuapp.com/dropdown"); 
        await Assertions.Expect(Page).ToHaveTitleAsync("The Internet"); 
        await Assertions.Expect(Page).ToHaveURLAsync("https://the-internet.herokuapp.com/dropdown"); 
        var dropDown = Page.Locator("#dropdown"); 
        await Assertions.Expect(dropDown).ToBeVisibleAsync();  
        await dropDown.SelectOptionAsync("1");  
        await Assertions.Expect(dropDown).ToHaveValueAsync("1"); 
        var selected1 = dropDown.Locator("option:checked"); 
        await Assertions.Expect(selected1).ToHaveTextAsync("Option 1"); 
        var text = await selected1.InnerTextAsync();
        text.Should().Be("Option 1"); 
        await dropDown.SelectOptionAsync("2"); 
        await Assertions.Expect(dropDown).ToHaveValueAsync("2");
    }

    
    [Test]
    public async Task CheckBoxes()
    {
        
    }
}