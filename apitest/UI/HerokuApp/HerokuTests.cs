using apitest.UI.Pages;
using FluentAssertions;
using Microsoft.Playwright;

namespace apitest.UI;

public class HerokuTests : BaseTest
{
    
    [Test]
    public async Task FormAuthentication()
    {
        LoginPage loginPage = new LoginPage(Page);
        loginPage.OpenLoginPageAsync();
        loginPage.Login("wrong", "wrong");
        var errorMessage = await loginPage.GetTextFromErrorMessageLabel();
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
    public async Task ShouldSelectSubItem()
    {
        await  Page.GotoAsync("https://demoqa.com/select-menu");
        var DropDown = Page.Locator("#withOptGroup");
        await  DropDown.ClickAsync();
        var option = Page.GetByText("Group 1, option 1");
    }
    
    [Test]
    public async Task AddRemoveElements()
    {
        // Открываем страницу
        await Page.GotoAsync("https://the-internet.herokuapp.com/add_remove_elements/");

        // Проверка title
        await Assertions.Expect(Page).ToHaveTitleAsync("The Internet");

        // Проверка URL
        await Assertions.Expect(Page).ToHaveURLAsync("https://the-internet.herokuapp.com/add_remove_elements/");

        // Локатор кнопки Add Element
        var addButton = Page.GetByRole(AriaRole.Button, new() { Name = "Add Element" });

        // Проверка видимости кнопки Add Element
        await Assertions.Expect(addButton).ToBeVisibleAsync();

        // Локатор всех Delete-кнопок
        var deleteButtons = Page.Locator("button.added-manually");

        // --- ДЕЙСТВИЕ 1: добавить первую кнопку ---
        await addButton.ClickAsync();

        // Проверка: появилась 1 кнопка Delete
        await Assertions.Expect(deleteButtons).ToHaveCountAsync(1);

        // --- ДЕЙСТВИЕ 2: добавить вторую кнопку ---
        await addButton.ClickAsync();

        // Проверка: теперь их 2
        await Assertions.Expect(deleteButtons).ToHaveCountAsync(2);

        // --- ДЕЙСТВИЕ 3: удалить одну кнопку ---
        await deleteButtons.Nth(0).ClickAsync();

        // Проверка: осталась 1 кнопка
        await Assertions.Expect(deleteButtons).ToHaveCountAsync(1);
    }


    [Test]
    public async Task JsAlertTest()
    {
        JavaScriptAlertsPage javaScriptAlertsPage = new JavaScriptAlertsPage(Page);
        await javaScriptAlertsPage.OpenAllertsPage();

        IDialog actualDialog = null;
        Page.Dialog += async (_, dialog) =>
        {
            actualDialog = dialog;
            await actualDialog.AcceptAsync();
        };
        await javaScriptAlertsPage.ClickJsAlertButtonAsync();
        actualDialog.Type.Should().Be("alert");
        actualDialog.Message.Should().Be("I am a JS Alert");
        
    }
}