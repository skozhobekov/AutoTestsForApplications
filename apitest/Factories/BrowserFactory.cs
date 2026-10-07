using Microsoft.Playwright;

    


public static class BrowserFactory
{
    // public static async Task<(IBrowser Browser, IPlaywright Playwright)> CreateAsync(Enums.BrowserType type)
    // {
    //     var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
    //
    //     var launchOptions = new BrowserTypeLaunchOptions
    //     {
    //         Headless = false,
    //         SlowMo = 3000,
    //         Args = new[] { "--start-maximized" }
    //     };

        // IBrowser browser = type switch
        // {
        //     Enums.BrowserType.Chromium => await playwright.Chromium.LaunchAsync(launchOptions),
        //     Enums.BrowserType.Firefox => await playwright.Firefox.LaunchAsync(launchOptions),
        //     Enums.BrowserType.WebKit => await playwright.Webkit.LaunchAsync(launchOptions),
        //     Enums.BrowserType
        //     _ => throw new ArgumentOutOfRangeException(nameof(type))
        // };

        //     return (browser, playwright);
        // }
        // }
}
