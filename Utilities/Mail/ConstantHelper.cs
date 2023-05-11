using System.Text;

namespace SamsungWatch.Utilities.Mail;

public class ConstantHelper
{

    public static string ToHexString(string str)
    {
        var sb = new StringBuilder();

        var bytes = Encoding.Unicode.GetBytes(str);
        foreach (var t in bytes)
        {
            sb.Append(t.ToString("X2"));
        }

        return sb.ToString();
    }

    public static string FromHexString(string hexString)
    {
        var bytes = new byte[hexString.Length / 2];
        for (var i = 0; i < bytes.Length; i++)
        {
            bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
        }

        return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
    }


    public static string hostMail = "smtp.gmail.com";
    public static int portEmail = 587;
    public static string email = "nguyenphuduc62001@gmail.com";
    public static string pass = "rkyeublqjfzkttta";
}