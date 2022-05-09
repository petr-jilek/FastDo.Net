using System.Security.Cryptography;
using System.Text;

namespace ApiCommon.Domain.Helpers
{
    /// <summary>
    /// Helper for generating Salt, Hash, ApiKey
    /// </summary>
    public class CryptographyHelper
    {
        /// <summary>
        /// Generate salt
        /// </summary>
        /// <returns>Random string of length 40</returns>
        public static string GenerateSalt()
            => GenerateRandomString(40);

        /// <summary>
        /// Generate ApiKey
        /// </summary>
        /// <returns>Random string of length 60</returns>
        public static string GenerateApiKey()
            => GenerateRandomString(60);

        /// <summary>
        /// Generate random string of specific size
        /// </summary>
        /// <param name="size">Size of random string</param>
        /// <returns>Random string of length size</returns>
        public static string GenerateRandomString(int size)
            => Convert.ToBase64String(RandomNumberGenerator.GetBytes(size));

        /// <summary>
        /// Perform SHA512 hash function to generate hash of the input
        /// </summary>
        /// <param name="input">Input string to be hashed</param>
        /// <param name="salt">Salt for hash</param>
        /// <returns>Hashed input string</returns>
        public static string GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            var hash = SHA512.HashData(bytes);
            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Verify if hashed input mathces hash. Use it for verifing passwords.
        /// </summary>
        /// <param name="input">Plain text input</param>
        /// <param name="hash">Hash</param>
        /// <param name="salt">Salt</param>
        /// <returns>Success of the verification</returns>
        public static bool Verify(string input, string hash, string salt)
        {
            string newHash = GenerateHash(input, salt);
            return newHash.Equals(hash);
        }
    }
}
