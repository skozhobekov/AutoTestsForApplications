using apitest.Storage.ForUI.Enums;
using apitest.Storage.ForUI.Models;

namespace apitest.Storage.ForUI.Builders;

public class StudentRegistrationBuilder
{
    private StudentRegistrationFormModel student =  new StudentRegistrationFormModel();

    public StudentRegistrationBuilder WithFirstName(string firstName)
    {
        student.FirstName = firstName;
        return this;
    }    
    
    public StudentRegistrationBuilder WithLastName(string lastName)
    {
        student.LastName = lastName;
        return this;
    }

    public StudentRegistrationBuilder WithEmail(string email)
    {
        student.Email = email;
        return this;
    }
    public StudentRegistrationBuilder WithGender(GenderType gender)
    {
        student.Gender = gender;
        return this;
    }
    
    public StudentRegistrationBuilder WithPostalCode(string postalCode)
    {
        student.PostalCode = postalCode;
        return this;
    }
    
    public StudentRegistrationFormModel Build()
    {
        return student;
    }

}