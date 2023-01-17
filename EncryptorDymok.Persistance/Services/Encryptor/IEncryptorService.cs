namespace EncryptorDymok.Persistence.Services.Encryptor;

public interface IEncryptorService
{
    byte[] EncryptStringToBytes_Aes(string plainText, string password);
    string DecryptStringFromBytes_Aes(byte[] cipherText, string password);
}