namespace apitest.Hooks.GroupTests;

public static class Validator
{
    public static bool IsValid(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) // проверяем, не пуста ли строка и нет ли в ней только пробелов
        {
            return false;
        }

        if (email.Contains(" ")) //нет ли пробелов в email
        {
            return false;
        }

        int dogIndex = email.IndexOf('@'); // ищем индекс символа @
        if (dogIndex <= 0 || dogIndex == email.Length - 1)
        {
            return dogIndex>0;
        }

        return false;
    }
}