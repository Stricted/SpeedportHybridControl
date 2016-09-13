using System;
using System.Security.Cryptography;
using System.Text;

namespace SpeedportHybridControl.Implementations
{
    public static class Cryptography
    {
        private static string GetKeyFromContainer()
        {
            // store key in keycontainer, this generates a new key if none exist
            CspParameters cp = new CspParameters();
            cp.KeyContainerName = "SpeedportHybridControl";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);
            return rsa.ToXmlString(true);
        }

        public static string Encrypt(string clearText)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            rsa.FromXmlString(GetKeyFromContainer());
            string result = Convert.ToBase64String(rsa.Encrypt(clearBytes, true));
            rsa.Dispose();

            return result;
        }

        public static string Decrypt(string cipherText)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            rsa.FromXmlString(GetKeyFromContainer());
            string result = Encoding.Unicode.GetString(rsa.Decrypt(cipherBytes, true));
            rsa.Dispose();

            return result;
        }
    }
}
