using System.Security.Cryptography;

namespace EncryptorDymok.ConsoleApplication;

public static class Program
{
    private static void Main(string[] args)
    {
        var plainText = "Hello, World!";
        var password = "my_secret_password";

        var encryptedBytes = EncryptStringToBytes_Aes(plainText, password);
        var decryptedText = DecryptStringFromBytes_Aes(encryptedBytes, password);

        Console.WriteLine("Encrypted: {0}", Convert.ToBase64String(encryptedBytes));
        Console.WriteLine("Decrypted: {0}", decryptedText);
    }

    private static byte[] EncryptStringToBytes_Aes(string plainText, string password)
    {
        byte[] encrypted;
        var salt = "dymka"u8.ToArray();
        using var aes = Aes.Create();
        var pdb = new Rfc2898DeriveBytes(password, salt);
        aes.Key = pdb.GetBytes(32);
        aes.IV = pdb.GetBytes(16);

        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
        using (var sw = new StreamWriter(cs))
        {
            sw.Write(plainText);
        }

        encrypted = ms.ToArray();

        return encrypted;
    }

    private static string? DecryptStringFromBytes_Aes(byte[] cipherText, string password)
    {
        var salt = "dymka"u8.ToArray();

        using var aes = Aes.Create();
        var pdb = new Rfc2898DeriveBytes(password, salt);
        aes.Key = pdb.GetBytes(32);
        aes.IV = pdb.GetBytes(16);

        using var ms = new MemoryStream(cipherText);
        using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        var plaintext = sr.ReadToEnd();

        return plaintext;
    }
}