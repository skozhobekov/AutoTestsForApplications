using apitest.Utils;
using Microsoft.Playwright;

namespace apitest.UI.DemoQA.UI.DataPicker;

public class DatePickerTests : BaseTest
{
    private DatePickerPage DatePickerPage;

    [SetUp]
    public async Task Setup()
    {
        DatePickerPage = new DatePickerPage(Page);
        await DatePickerPage.OpenAsync();
    }

    [Test]
    public async Task ShouldSelectDateInDatePicker()
    {
        await DatePickerPage.SelectDateAsync(15);

        var selectedDate = await DatePickerPage.GetSelectedDateValueAsync();

        Assert.That(selectedDate, Contains.Substring("15"),
            $"Ожидалось, что выбранная дата будет содержать '15', но получили: {selectedDate}");
    }

    [Test]
    public async Task ShouldSelectDateAndTimeInDateTimePicker()
    {
        await DatePickerPage.SelectDateAndTimeAsync("October", 2026, 6, "09:30");
        var selectedValue = await DatePickerPage.GetSelectedDateAndTimeValueAsync();

        Assert.That(selectedValue, Contains.Substring("October"),
            $"Ожидалось, что месяц будет October, но получили: {selectedValue}");
        Assert.That(selectedValue, Contains.Substring("2026"),
            $"Ожидалось, что год будет 2026, но получили: {selectedValue}");
        Assert.That(selectedValue, Contains.Substring("9:30"),
            $"Ожидалось, что время будет 9:30, но получили: {selectedValue}");
    }

    [Test]
    public async Task ShouldTypeDateInDatePicker()
    {
        var date = DateTimeUtils.GetFutureDateString(6, DateTimeConstants.MonthDayYearSlashFormat);
        await DatePickerPage.FillDataAsync(date);
        var selectedDate = await DatePickerPage.GetSelectedDateValueAsync();
        Assert.That(selectedDate, Is.EqualTo(date));
    }
}