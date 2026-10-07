namespace apitest.Hooks.DataProvider;

public static class EmailTestDataProvider
{
    private static readonly string emailDataFilePath =
        Path.Combine("Resources", "Configs.csv");

    public static  IEnumerable<TestCaseData> GetEmailCases()
    {
        //получаем директорию в которой исполняется процесс запуска автотестов
        string baseDirectory = AppContext.BaseDirectory;
        //формируем путь к файлу с емейлами
        string fullPath = Path.Combine(baseDirectory, emailDataFilePath);
        //читаем все строки из файла
        var lines = File.ReadAllLines(fullPath);

        for ( int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(',');
            string email = parts[0];
            bool result = bool.Parse(parts[1]);
            yield return new TestCaseData(email, result);
        }
    }

}