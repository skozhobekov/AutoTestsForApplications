using apitest.Storage.ForUI.Builders;
using apitest.Storage.ForUI.Enums;
using apitest.Storage.ForUI.Models;

namespace apitest.UI.DemoQA.UI;


[TestFixture]
public class DemoQaTest: BaseTest
{
    [Test]
    public async Task FillStudentRegistrationForm()
    {
        await Page.GotoAsync("https://demoqa.com/automation-practice-form");
        StudentRegistrationBuilder builder = new StudentRegistrationBuilder();
        var studentData = builder.WithFirstName("Rajesh")
            .WithLastName("Kutrapali")
            .WithEmail("rajeshKutrapali@gmail.com")
            .WithGender(GenderType.Male)
            .Build();
        
        await FillFormAsync(studentData);
    }

    public async Task FillFormAsync(StudentRegistrationFormModel studentData)
    {
        await Page.Locator("#firstName").FillAsync(studentData.FirstName);
        await Page.Locator("#lastName").FillAsync(studentData.LastName);
        await Page.Locator("#userEmail").FillAsync(studentData.Email);
        
    }
    
    
    [Test]
    
    public async Task SelectProfessorFromDropdown()
    {
        await Page.GotoAsync("https://demoqa.com/select-menu");

        // Открываем Select One
        await Page.Locator("#selectOne").ClickAsync();

        // Выбираем Prof
        await Page.GetByText("Prof.", new() { Exact = true }).ClickAsync();

        // Проверяем, что выбрали Prof
        var selectedValue = await Page.Locator(".css-1dimb5e-singleValue").InnerTextAsync();
        Assert.That(selectedValue, Is.EqualTo("Prof."));
    }
}