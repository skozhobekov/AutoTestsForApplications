using FluentAssertions;

namespace apitest.UI;

public class SauceDemoTests: BaseTest
{
    [Test]
    public async Task Authentication()
    {
            await Page.GotoAsync("https://www.saucedemo.com/");
            var userNameField = Page.Locator("#user-name");
            await userNameField.FillAsync("standard_user");
            var passField = Page.Locator("#password");
            await passField.FillAsync("secret_sauce");
            var loginButton = Page.Locator("#login-button");
            await loginButton.ClickAsync();
            var products = Page.Locator("//*[@data-test='title']");
            var headerText = await products.InnerTextAsync();
            headerText.Should().Be("Products");
        }
    }
    