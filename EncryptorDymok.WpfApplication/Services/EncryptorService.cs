using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncryptorDymok.WpfApplication.Services
{
    internal class EncryptorService
    {
        public static byte[] EncryptStringToBytes_Aes(string plainText, string password)
        {
            byte[] encrypted;
            var salt = Encoding.ASCII.GetBytes("dymka");
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

        public static string? DecryptStringFromBytes_Aes(byte[] cipherText, string password)
        {
            var salt = Encoding.ASCII.GetBytes("dymka");

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
}
