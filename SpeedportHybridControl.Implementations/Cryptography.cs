using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SpeedportHybridControl.Implementations
{
    public static class Cryptography
    {
        private static string KEY = "8E16A57381AFDA47856682CEBE85DCF5982F59321AE28B2822C1C9E1FC481C50";
        private static string IV = "7CD37E78623793D4C4BB81DB73B08522";

        public static string Encrypt(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            string result;
            using (Aes encryptor = Aes.Create())
            {
                if (Object.Equals(encryptor, null))
                {
                    result = null;
                    return result;
                }

                encryptor.KeySize = 256;
                encryptor.BlockSize = 128;
                encryptor.Mode = CipherMode.CBC;
                encryptor.Padding = PaddingMode.PKCS7;
                encryptor.Key = util.HexToByte(KEY);
                encryptor.IV = util.HexToByte(IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            result = clearText;
            return result;
        }

        public static string Decrypt(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            string result;
            using (Aes encryptor = Aes.Create())
            {
                if (Object.Equals(encryptor, null))
                {
                    result = null;
                    return result;
                }

                encryptor.KeySize = 256;
                encryptor.BlockSize = 128;
                encryptor.Mode = CipherMode.CBC;
                encryptor.Padding = PaddingMode.PKCS7;
                encryptor.Key = util.HexToByte(KEY);
                encryptor.IV = util.HexToByte(IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            result = cipherText;
            return result;
        }
    }
}
