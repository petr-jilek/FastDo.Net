using System.Security.Cryptography;
using System.Text;
using FastDo.Net.Domain.Enums;

namespace FastDo.Net.Api.Helpers
{
    /// <summary>
    /// Helper for generating Salt, Hash, ApiKey
    /// </summary>
    public class CryptographyHelper
    {
        /// <summary>
        /// Generate salt
        /// </summary>
        /// <returns>Random string of length 40 in base64</returns>
        public static string GenerateSalt()
            => GenerateRandomString(40);

        /// <summary>
        /// Generate ApiKey
        /// </summary>
        /// <returns>Random string of length 60 in base64</returns>
        public static string GenerateApiKey()
            => GenerateRandomString(60);

        /// <summary>
        /// Generate ClientId
        /// </summary>
        /// <returns>Random string of length 20 in base64</returns>
        public static string GenerateClientId()
           => GenerateRandomString(20);

        /// <summary>
        /// Generate ClientSecret
        /// </summary>
        /// <returns>Random string of length 40 in base64</returns>
        public static string GenerateClientSecret()
           => GenerateRandomString(40);

        /// <summary>
        /// Generate EmailVerificationToken
        /// </summary>
        /// <returns>Random string of length 60 in base64</returns>
        public static string GenerateEmailVerificationToken()
            => GenerateRandomString(60);

        /// <summary>
        /// Generate random string of specific size
        /// </summary>
        /// <param name="size">Size of random string</param>
        /// <returns>Random string in base64 of length specified by parameter: size</returns>
        public static string GenerateRandomString(int size)
            => Convert.ToBase64String(RandomNumberGenerator.GetBytes(size));

        /// <summary>
        /// Generate random int number of specified digits
        /// </summary>
        /// <param name="digits">Number of digits</param>
        /// <returns>Random int number of specified digits</returns>
        public static int GenerateRandomNumberFixedDigits(int digits)
        {
            var numberString = "";

            for (var i = 0; i < digits; i++)
            {
                var randomInt = RandomNumberGenerator.GetInt32(0, 10);

                if (randomInt == 0)
                    randomInt++;

                numberString += randomInt.ToString();
            }

            return int.Parse(numberString);
        }

        /// <summary>
        /// Perform SHA512 hash function to generate hash of the input
        /// </summary>
        /// <param name="input">Input string to be hashed</param>
        /// <param name="salt">Salt for hash</param>
        /// <param name="hashMethod">HashMethod by which the input will be hashed</param>
        /// <returns>Hashed input string</returns>
        public static string CreateHash(string input, string salt, HashMethod hashMethod)
        {
            var bytes = Encoding.UTF8.GetBytes(input + salt);

            var hash = hashMethod switch
            {
                HashMethod.Sha256 => SHA256.HashData(bytes),
                HashMethod.Sha512 => SHA512.HashData(bytes),
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
        /// <param name="hashMethod">HashMethod</param>
        /// <returns>Success of the verification</returns>
        public static bool Verify(string input, string hash, string salt, HashMethod hashMethod)
        {
            var newHash = CreateHash(input, salt, hashMethod);
            return newHash.Equals(hash);
        }
    }
}
