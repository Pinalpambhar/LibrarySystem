using System;
using System.Security.Cryptography;
using System.Text;

namespace LibraryBusinessLogic.BL
{
    public class Cryptography
    {
        #region Private Members
        private string _encryptionkey = "A!9HHhi%XjjYY4YP";
        public byte[] data;
        #endregion

        #region Public Methods
        /// <summary>
        /// Encrpt Given String
        /// </summary>
        /// <param name="value">Plain Text</param>
        /// <returns>Encrypted String</returns>
        public string Encrypt(string value)
        {
            try
            {
                RijndaelManaged cipher = new RijndaelManaged
                {
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7,

                    KeySize = 128,
                    BlockSize = 128
                };

                byte[] pwdbytes = Encoding.UTF8.GetBytes(_encryptionkey);
                byte[] keybytes = new byte[16];
                int length = pwdbytes.Length;

                if (length > keybytes.Length)
                {
                    length = keybytes.Length;
                }
                Array.Copy(pwdbytes, keybytes, length);
                cipher.Key = keybytes;
                cipher.IV = keybytes;

                ICryptoTransform transform = cipher.CreateEncryptor();
                byte[] PlainText = Encoding.UTF8.GetBytes(value);

                data = transform.TransformFinalBlock(PlainText, 0, PlainText.Length);
                return Convert.ToBase64String(data);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Decrypt given string
        /// </summary>
        /// <param name="value">Encrypted Text</param>
        /// <returns>Decrypted string</returns>
        public string Decrypt(string value)
        {
            try
            {
                RijndaelManaged cipher = new RijndaelManaged
                {
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7,

                    KeySize = 128,
                    BlockSize = 128
                };

                byte[] pwdbytes = Encoding.UTF8.GetBytes(_encryptionkey);
                byte[] keybytes = new byte[16];
                int length = pwdbytes.Length;
                if (length > keybytes.Length)
                {
                    length = keybytes.Length;
                }
                Array.Copy(pwdbytes, keybytes, length);
                cipher.Key = keybytes;
                cipher.IV = keybytes;

                ICryptoTransform transform = cipher.CreateDecryptor();
                byte[] encryptData = Convert.FromBase64String(value);

                return Encoding.UTF8.GetString(transform.TransformFinalBlock(encryptData, 0, encryptData.Length));
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
