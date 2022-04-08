using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace OroClient.Utils
{
    public static class Wsse
    {
        public static string GenerateHeader()
        {
            string userName = "admin";
            string userApiKey = "2df509bbf8580073547f13ac2a429bfeb188652f";
            string encryptionValue = CreateMD5(GetUniqID());
            string nonce = Base64Encode(encryptionValue.Substring(0, 16));
            string created = DateTime.UtcNow.ToString();
            string digestValue = CreateSha1(Base64Decode($"{nonce}{created}{userApiKey}"));
            string digest = Base64Encode(digestValue);


            return $"UsernameToken Username={userName}, PasswordDigest={digest}, Nonce={nonce}, Created={created}";
        }

        private static string GetUniqID()
        {
            var ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            double t = ts.TotalMilliseconds / 1000;

            int a = (int)Math.Floor(t);
            int b = (int)((t - Math.Floor(t)) * 1000000);

            return a.ToString("x8") + b.ToString("x5");
        }

        private static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static string Base64Encode(string plainText)
        {
            var binary = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(binary);
        }

        public static string Base64Decode(string data)
        {
            byte[] binary = Convert.FromBase64String(data);
            return Encoding.Default.GetString(binary);
        }

        private static string CreateSha1(string password)
        {
            return string.Join("", SHA1CryptoServiceProvider.Create().ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("x2")));
        }
    }
}
