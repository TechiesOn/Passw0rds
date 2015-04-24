using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Passw0rds
{
    public class PasswordGenerator
    {
        public static string GetAlphaNumeric(int size)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();          
            return GetPassword(size, chars);
        }

        public static string GetSpecialChars(int size)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!$%&*".ToCharArray();
            return GetPassword(size, chars);
        }

        private static string GetPassword(int size, IList<char> chars)
        {
            var data = new byte[1];
            using (var crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[size];
                crypto.GetNonZeroBytes(data);
            }
            var result = new StringBuilder(size);
            foreach (var b in data)
            {
                result.Append(chars[b%(chars.Count)]);
            }
            return result.ToString();
        }
    }
}
