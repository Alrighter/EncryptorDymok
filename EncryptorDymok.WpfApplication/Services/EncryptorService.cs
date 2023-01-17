using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EncryptorDymok.WpfApplication.Services;

public static class EncryptionService
{
    private static readonly Dictionary<char, char> _charDictionary = new()
    {
        {'a', 'z'}, {'b', 'y'}, {'c', 'x'}, {'d', 'w'}, {'e', 'v'}, {'f', 'u'},
        {'g', 't'}, {'h', 's'}, {'i', 'r'}, {'j', 'q'}, {'k', 'p'}, {'l', 'o'},
        {'m', 'n'}, {'n', 'm'}, {'o', 'l'}, {'p', 'k'}, {'q', 'j'}, {'r', 'i'},
        {'s', 'h'}, {'t', 'g'}, {'u', 'f'}, {'v', 'e'}, {'w', 'd'}, {'x', 'c'},
        {'y', 'b'}, {'z', 'a'}, {'A', 'Z'}, {'B', 'Y'}, {'C', 'X'}, {'D', 'W'},
        {'E', 'V'}, {'F', 'U'}, {'G', 'T'}, {'H', 'S'}, {'I', 'R'}, {'J', 'Q'},
        {'K', 'P'}, {'L', 'O'}, {'M', 'N'}, {'N', 'M'}, {'O', 'L'}, {'P', 'K'},
        {'Q', 'J'}, {'R', 'I'}, {'S', 'H'}, {'T', 'G'}, {'U', 'F'}, {'V', 'E'},
        {'W', 'D'}, {'X', 'C'}, {'Y', 'B'}, {'Z', 'A'}, {'0', '2'}, {'1', '4'},
        {'2', '0'}, {'3', '6'}, {'4', '1'}, {'5', '7'}, {'6', '3'}, {'7', '5'},
        {'8', '9'}, {'9', '8'}, {'!', '@'}, {'@', '!'}, {'#', '$'}, {'$', '#'},
        {'%', '^'}, {'^', '%'}, {'&', '*'}, {'*', '&'}, {'(', ')'}, {')', '('},
        {'-', '+'}, {'+', '-'}, {'=', '_'}, {'_', '='}, {'[', ']'}, {']', '['},
        {'{', '}'}, {'}', '{'}, {';', ':'}, {':', ';'}, {'"', '\''}, {'\'', '"'},
        {'<', '>'}, {'>', '<'}, {',', '.'}, {'.', ','}, {'?', '/'}, {'/', '?'},
        {'`', '~'}, {'~', '`'}, {'А', 'Є'}, {'Е', 'І'}, {'Є', 'А'}, {'И', 'У'},
        {'І', 'Е'}, {'Ї', 'Ю'}, {'О', 'Я'}, {'У', 'И'}, {'Ю', 'Ї'}, {'Я', 'О'},
        {'а', 'є'}, {'е', 'і'}, {'є', 'а'}, {'и', 'у'}, {'і', 'е'}, {'ї', 'ю'},
        {'о', 'я'}, {'у', 'и'}, {'ю', 'ї'}, {'я', 'о'}, {'Б', 'Ґ'}, {'В', 'Ж'},
        {'Г', 'З'}, {'Ґ', 'Б'}, {'Ж', 'В'}, {'З', 'Г'}, {'Й', 'М'}, {'К', 'Н'},
        {'Л', 'П'}, {'М', 'Й'}, {'Н', 'К'}, {'П', 'Л'}, {'Р', 'Ф'}, {'С', 'Х'},
        {'Т', 'Ц'}, {'Ф', 'Р'}, {'Х', 'С'}, {'Ц', 'Т'}, {'Ч', 'Щ'}, {'Ш', 'Ь'},
        {'Щ', 'Ч'}, {'Ь', 'Ш'}, {'б', 'ґ'}, {'в', 'ж'}, {'г', 'з'}, {'ґ', 'б'},
        {'ж', 'в'}, {'з', 'г'}, {'й', 'м'}, {'к', 'н'}, {'л', 'п'}, {'м', 'й'},
        {'н', 'к'}, {'п', 'л'}, {'р', 'ф'}, {'с', 'х'}, {'т', 'ц'}, {'ф', 'р'},
        {'х', 'с'}, {'ц', 'т'}, {'ч', 'щ'}, {'ш', 'ь'}, {'щ', 'ч'}, {'ь', 'ш'}
    };

    public static string SimpleEncrypt(string input)
    {
        try
        {
            var encryptedText =
                new string(input.Select(c => _charDictionary.ContainsKey(c) ? _charDictionary[c] : c).ToArray());
            return encryptedText;
        }
        catch (Exception e)
        {
            return e.Message + Environment.NewLine + e.StackTrace + Environment.NewLine + input;
        }
    }

    public static string SimpleDecrypt(string input)
    {
        try
        {
            var decryptedText = new string(input.Select(c =>
                _charDictionary.ContainsValue(c) ? _charDictionary.First(x => x.Value == c).Key : c).ToArray());
            return decryptedText;
        }
        catch (Exception e)
        {
            return e.Message + Environment.NewLine + e.StackTrace + Environment.NewLine + input;
        }
    }

    //Create encrypt method
    [Obsolete("Obsolete")]
    public static string EncryptText(string text, string key)
    {
        var toEncryptArray = Encoding.UTF8.GetBytes(text);

        //Get hash code
        var hashmd5 = new MD5CryptoServiceProvider();
        var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
        hashmd5.Clear();

        //Set encryptor
        var tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        //Transform
        var cTransform = tdes.CreateEncryptor();
        var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        tdes.Clear();

        //Return the encrypted text
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    //Create decrypt method
    [Obsolete("Obsolete")]
    public static string DecryptText(string text, string key)
    {
        try
        {
            var toEncryptArray = Convert.FromBase64String(text);

            //Get hash code
            var hashmd5 = new MD5CryptoServiceProvider();
            var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();

            //Set encryptor
            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //Transform
            var cTransform = tdes.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();

            //Return the decrypted text
            return Encoding.UTF8.GetString(resultArray);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return e.Message + "\n\nThe key or text is not valid!";
        }
    }

    //Encrypt method with custom alphabet
}