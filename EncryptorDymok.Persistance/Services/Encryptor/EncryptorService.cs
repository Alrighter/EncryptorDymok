using System.Security.Cryptography;
using System.Text;

namespace EncryptorDymok.Persistance.Services.Encryptor;

public class EncryptorService
{
    private static byte[] EncryptStringToBytes_Aes(string plainText, string password)
    {
        byte[] encrypted;
        var salt = "salt_value"u8.ToArray();
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

    private static string DecryptStringFromBytes_Aes(byte[] cipherText, string password)
    {
        var salt = "salt_value"u8.ToArray();
        string plaintext = null;

        using var aes = Aes.Create();
        var pdb = new Rfc2898DeriveBytes(password, salt);
        aes.Key = pdb.GetBytes(32);
        aes.IV = pdb.GetBytes(16);

        using var ms = new MemoryStream(cipherText);
        using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        plaintext = sr.ReadToEnd();

        return plaintext;
    }
}