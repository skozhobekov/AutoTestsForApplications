using System.Globalization;
using System.Runtime.InteropServices.JavaScript;

namespace apitest.Utils;

public class DateTimeUtils
{
    public static string GetFutureDateString( int day, string format)
    {
        return DateTime.Now.AddDays(day).ToString(format, CultureInfo.InvariantCulture);
    }

}