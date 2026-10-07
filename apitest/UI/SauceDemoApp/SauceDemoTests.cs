using apitest.UI.Builders;
using apitest.UI.Models;
using apitest.UI.Pages;
using FluentAssertions;
using Microsoft.Playwright;

namespace apitest.UI;


[TestFixture]
public class SauceDemoTests: BaseTest


{
    [Test]
    public async Task LoginTest() // добавил Builder
    {
        await Page.GotoAsync("https://www.saucedemo.com/");
        UserLoginBuilder builder = new UserLoginBuilder();
        var userData = builder.WithUserName("standard_user")
            .WithPassword("secret_sauce")
            .Build();
        SauceLoginPage sauceLoginPage = new SauceLoginPage(Page);
        await sauceLoginPage.FulFillFields(userData);
        await sauceLoginPage.Submit();
        await sauceLoginPage.CheckAuth(); 
    }
    [Test]
    public async Task MakeOrderCheckTest()
    {
        await Page.GotoAsync("https://www.saucedemo.com/");
        UserLoginBuilder builder = new UserLoginBuilder();
        var userData = builder.WithUserName("standard_user")
            .WithPassword("secret_sauce")
            .Build();
        SauceLoginPage sauceLoginPage = new SauceLoginPage(Page);
        MainPage mainPage = new MainPage(Page);
        await  sauceLoginPage.FulFillFields(userData);
        await sauceLoginPage.Submit();
        await sauceLoginPage.CheckAuth();
        await mainPage.AddProductToCart("Sauce Labs Backpack");
        await mainPage.AddProductToCart("Sauce Labs Bike Light");
        await mainPage.GoToCart();
        await mainPage.CheckProductInCart("Sauce Labs Bike Light");
        await mainPage.CheckProductInCart("Sauce Labs Backpack");
        YourCartPage cartPage = new YourCartPage(Page);
        await cartPage.CheckoutButtonClick();
        InformationPage  informationPage = new InformationPage(Page);
        await informationPage.FillThreeFieldsAndContinue("Kozhobekov", "Sanjar", "776");
        //KozhobekovSanjar776
        OverviewPage overviewPage = new OverviewPage(Page);
        await overviewPage.CheckProduct("Sauce Labs Backpack");
        await overviewPage.CheckProduct("Sauce Labs Bike Light");
        await overviewPage.Finish();
        await overviewPage.CheckOrderComplete();


    }

    
}
    