using System.Security.Cryptography;
using System.Text;
using FastDo.Net.Domain.Enums;
using FastDo.Net.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace FastDo.Net.Api.Helpers
{
    /// <summary>
    /// Helper for generating Salt, Hash, ApiKey
    /// </summary>
    public class CryptographyHelper
    {
        /// <summary>
        /// Generate random string of specific size
        /// </summary>
        /// <param name="size">Size of random string</param>
        /// <returns>Random string in base64 of length specified by parameter: size</returns>
        public static string GenerateRandomString(int size)
            => Base64UrlEncoder.Encode(RandomNumberGenerator.GetBytes(size));

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
        /// Verify if hashed input matches hash. Use it for verifing passwords.
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

        /// <summary>
        /// Verify if hashed input matches hash in password credentials with salt. Use it for verifing passwords.
        /// </summary>
        /// <param name="input">Plain text input</param>
        /// <param name="passwordCredentials">Password credentials</param>
        /// <returns>Success of the verification</returns>
        public static bool Verify(string input, PasswordCredentials passwordCredentials)
        {
            var newHash = CreateHash(input, passwordCredentials.Salt!, (HashMethod)passwordCredentials.HashMethod);
            return newHash.Equals(passwordCredentials.Hash);
        }

        /// <summary>
        /// Generate salt and create hash
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="hashMethod">HashMethod</param>
        /// <returns>Salt and hash</returns>
        public static (string, string) CreateSaltAndHash(string input, HashMethod hashMethod)
        {
            var salt = GenerateSalt();
            var hash = CreateHash(input, salt, hashMethod);
            return (salt, hash);
        }

        /// <summary>
        /// Generate salt and create hash with Sha256
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="hashMethod">HashMethod</param>
        /// <returns>Salt and hash</returns>
        public static (string, string) CreateSaltAndHashSha256(string input)
            => CreateSaltAndHash(input, HashMethod.Sha256);

        /// <summary>
        /// Generate salt and create hash with Sha512
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="hashMethod">HashMethod</param>
        /// <returns>Salt and hash</returns>
        public static (string, string) CreateSaltAndHashSha512(string input)
            => CreateSaltAndHash(input, HashMethod.Sha512);

        /// <summary>
        /// Create password credentials like salt, hash and hashMethod from string input
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="hashMethod">HashMethod</param>
        /// <returns>PasswordCredentials</returns>
        public static PasswordCredentials CreatePasswordCredentials(string input, HashMethod hashMethod)
        {
            (var salt, var hash) = CreateSaltAndHash(input, hashMethod);
            return new PasswordCredentials()
            {
                Salt = salt,
                Hash = hash,
                HashMethod = (int)hashMethod,
            };
        }

        /// <summary>
        /// Create password credentials like salt, hash and hashMethod from string input with hashMethod Sha256
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>PasswordCredentials</returns>
        public static PasswordCredentials CreatePasswordCredentialsSha256(string input)
            => CreatePasswordCredentials(input, HashMethod.Sha256);

        /// <summary>
        /// Create password credentials like salt, hash and hashMethod from string input with hashMethod Sha512
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>PasswordCredentials</returns>
        public static PasswordCredentials CreatePasswordCredentialsSha512(string input)
             => CreatePasswordCredentials(input, HashMethod.Sha512);

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
        /// Generate EmailVerificationCredentials
        /// </summary>
        /// <returns>EmailVerificationCredentials</returns>
        public static EmailVerificationCredentials GenerateEmailVerificationCredentials()
            => new EmailVerificationCredentials()
            {
                Token = GenerateEmailVerificationToken(),
                Verified = false,
            };
    }
}
