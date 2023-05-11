namespace SamsungWatch.Utilities;

public static class SystemVariable
{
    public static string GetRanDomCode(int length)
    {
        Random random = new Random();
        const string chars = "1234567890";

        IEnumerable<string> string_Enumerable = Enumerable.Repeat(chars, length);
        char[] arr = string_Enumerable.Select(s => s[random.Next(s.Length)]).ToArray();

        return new string(arr);
    }

    public static string NonUnicode(this string text)
    {
        var arr1 = new[] { " " };
        var arr2 = new[] { "_" };
        for (var i = 0; i < arr1.Length; i++)
        {
            text = text.Replace(arr1[i], arr2[i]);
            text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
        }

        return text;
    }
}