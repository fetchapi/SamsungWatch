using System;
using System.Security.Cryptography;
using System.Text;

namespace SamsungWatch.Utilities;

public static class MD5Encrypt
{
    public static string Encrypt(string? str)
    {
        if (str == null)
        {
            str = "";
        }
        MD5 mh = MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(str);
        byte[] hash = mh.ComputeHash(inputBytes);
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }
}

