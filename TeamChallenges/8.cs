using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace InsecureCryptographyLibrary
{
    public class InsecureCryptography
    {
        // 1. SHA-256 Hashing (Strong Cryptography)
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        // 2. Storing sensitive data securely
        public static void StoreData(string data)
        {
            string encryptedData = EncryptDataWithAES(data);
            File.WriteAllText("sensitiveData.txt", encryptedData); // Storing data securely
        }


        // 3. Secure Token Generation (Secure Randomness)
        public static string GenerateToken()
        {
            byte[] tokenBytes = new byte[16];
            RandomNumberGenerator.Create().GetBytes(tokenBytes);
            return Convert.ToBase64String(tokenBytes); // Secure token generation
        }

        // 4. Using strong ciphers (AES)
        public static string EncryptDataWithAES(string data)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes("A very strong key123"); // Use a strong key (16 bytes)
                aes.IV = Encoding.UTF8.GetBytes("A strong IV123456"); // Use a strong IV (16 bytes)
                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                    return Convert.ToBase64String(encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length));
                }
            }
        }

        // 5. Storing session tokens securely
        public static void StoreSessionToken(string token)
        {
            string encryptedToken = EncryptDataWithAES(token);
            File.AppendAllText("sessionTokens.txt", encryptedToken); // Secure storage of session tokens
        }
    }
}
