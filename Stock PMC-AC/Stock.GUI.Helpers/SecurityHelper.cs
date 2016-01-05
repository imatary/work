using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Stock.GUI.Helpers
{
    public static class SecurityHelper
    {
        private const string Message = "UMCSTOCK";

        #region Cryptography
        /// <summary>
        /// Mã Hóa Mật Khẩu
        /// </summary>
        /// <param name="encryptkey"></param>
        /// <returns></returns>
        public static string Encrypt(string encryptkey)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptkey);
            using (Aes encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(Message, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                if (encryptor != null)
                {
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        encryptkey = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            return encryptkey;
        }

        /// <summary>
        /// Giải Mã Mật Khẩu
        /// </summary>
        /// <param name="decryptKey"></param>
        /// <returns></returns>
        public static string Decrypt(string decryptKey)
        {
            byte[] cipherBytes = Convert.FromBase64String(decryptKey);
            using (Aes encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(Message, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                if (encryptor != null)
                {
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        decryptKey = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            return decryptKey;
        }

        #endregion
    }
}
