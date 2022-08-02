using System.Security.Cryptography;
using System.Text;
using ApiCommon.Application.Enums;

namespace ApiCommon.Application.Helpers
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

        public static string GenerateClientId()
           => GenerateRandomString(20);

        public static string GenerateClientSecret()
           => GenerateRandomString(40);

        public static string GenerateEmailConfirmationToken()
            => GenerateRandomString(60);

        /// <summary>
        /// Generate random string of specific size
        /// </summary>
        /// <param name="size">Size of random string</param>
        /// <returns>Random string of length size</returns>
        public static string GenerateRandomString(int size)
            => Convert.ToBase64String(RandomNumberGenerator.GetBytes(size));

        public static int GenerateRandomNumberFixedDigits(int digits)
        {
            var numberString = "";

            for (var i = 0; i < digits; i++)
            {
                numberString += RandomNumberGenerator.GetInt32(0, 10).ToString();
            }

            return int.Parse(numberString);
        }
        /// <summary>
        /// Perform SHA512 hash function to generate hash of the input
        /// </summary>
        /// <param name="input">Input string to be hashed</param>
        /// <param name="salt">Salt for hash</param>
        /// <returns>Hashed input string</returns>
        public static string CreateHash(string input, string salt, HashMethod hashMethod)
        {
            var bytes = Encoding.UTF8.GetBytes(input + salt);

            var hash = hashMethod switch
            {
                HashMethod.SHA256 => SHA256.HashData(bytes),
                HashMethod.SHA512 => SHA512.HashData(bytes),
                _ => SHA512.HashData(bytes)
            };

            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Verify if hashed input mathces hash. Use it for verifing passwords.
        /// </summary>
        /// <param name="input">Plain text input</param>
        /// <param name="hash">Hash</param>
        /// <param name="salt">Salt</param>
        /// <returns>Success of the verification</returns>
        public static bool Verify(string input, string hash, string salt, HashMethod hashMethod)
        {
            var newHash = CreateHash(input, salt, hashMethod);
            return newHash.Equals(hash);
        }
    }
}
