using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SpeedportHybridControl.Implementations {
	public static class Cryptography {
		private static string EncryptionKey = "FD25B8d0afB9DDB";
		private static byte[] salt = new byte[] { 82, 9, 106, 213, 48, 54, 165, 56, 191, 64, 163, 158, 129 };

		public static string Encrypt (string clearText) {
			byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
			string result;
			using (Aes encryptor = Aes.Create()) {
				if (Object.Equals(encryptor, null)) {
					result = null;
					return result;
				}

				Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, salt);
				encryptor.Key = pdb.GetBytes(32);
				encryptor.IV = pdb.GetBytes(16);
				using (MemoryStream ms = new MemoryStream()) {
					using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)) {
						cs.Write(clearBytes, 0, clearBytes.Length);
						cs.Close();
					}
					clearText = Convert.ToBase64String(ms.ToArray());
				}
			}
			result = clearText;
			return result;
		}

		public static string Decrypt (string cipherText) {
			byte[] cipherBytes = Convert.FromBase64String(cipherText);
			string result;
			using (Aes encryptor = Aes.Create()) {
				if (Object.Equals(encryptor, null)) {
					result = null;
					return result;
				}

				Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, salt);
				encryptor.Key = pdb.GetBytes(32);
				encryptor.IV = pdb.GetBytes(16);
				using (MemoryStream ms = new MemoryStream()) {
					using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)) {
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
