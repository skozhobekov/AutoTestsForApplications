using apitest.UI.Models;

namespace apitest.UI.Builders;

public class UserLoginBuilder
{
    private UserLoginFormModel user = new UserLoginFormModel();

    public UserLoginBuilder WithUserName(string userName)
    {
        user.UserName = userName;
        return this;
    }

    public UserLoginBuilder WithPassword(string password)
    {
        user.Password = password;
        return this;
    }

    public UserLoginFormModel Build()
    {
        return user;
    }
}