using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CCCWebAPI.Common
{
    public class CommonEncryptDecrypt
    {
        public static string encrypt(string encryptString)
        {
            var key = Encoding.UTF8.GetBytes("094GeevezwDAADwz");
            var iv = Encoding.UTF8.GetBytes("094GeevezwDAADwz");

            // Create a RijndaelManaged object  
            // with the specified key and IV.  
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.KeySize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.  
                var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.  
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.  
                            swEncrypt.Write(encryptString);
                        }
                        encryptString = Convert.ToBase64String(msEncrypt.ToArray()).Replace('+', '-').Replace('/', '_');
                    }
                }
            }
            // Return the encrypted bytes from the memory stream. 
            return encryptString;
        }

        public static string Decrypt(string cipherText)
        {
            cipherText = cipherText.Replace('_', '/').Replace('-', '+').Replace(" ", "+");

            var key = Encoding.UTF8.GetBytes("094GeevezwDAADwz");
            var iv = Encoding.UTF8.GetBytes("094GeevezwDAADwz");

            using (var rijAlg = new RijndaelManaged())
            {
                //Settings  
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.KeySize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.  
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                try
                {
                    // Create the streams used for decryption.  
                    using (var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {

                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream  
                                // and place them in a string.  
                                cipherText = srDecrypt.ReadToEnd();

                            }

                        }
                    }
                }
                catch
                {
                    cipherText = "keyError";
                }
            }

            return cipherText;
        }
    }
}
