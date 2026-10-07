using Microsoft.Playwright;

namespace apitest.UI;

public class PlaywrightFixture : IAsyncDisposable
{
    public IPlaywright Playwright { get; private set; }
    public IBrowser Browser { get; private set; }

    public async Task InitializeAsync()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 2000,
            Args = new[] { "--start-maximized" }
        });
<<<<<<< HEAD
    }

    public async ValueTask DisposeAsync()
    {
        if(Browser!=null)
        {
            await Browser.CloseAsync();
        }
        Playwright?.Dispose();
    }

=======

        }
        // public async Task InitializeAsync(Enums.BrowserType type = Enums.BrowserType.Chromium)
        // {
        //     var result = await BrowserFactory.CreateAsync(type);
        //     Browser = result.Browser;
        //     Playwright = result.Playwright;
        // }


        public async ValueTask DisposeAsync()
        {
            if (Browser != null)
            {
                await Browser.CloseAsync();
            }

            Playwright?.Dispose();
        }
>>>>>>> homework-13-pr
}