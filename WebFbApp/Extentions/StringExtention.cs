using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebFbApp.Extentions
{
    public static class StringExtention
    {
        public static string GenerateAppSecretProof(this String accessToken)
        {
            using (HMACSHA256 algorithm = new HMACSHA256(Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["Facebook_AppSecret"])))
            {
                byte[] hash = algorithm.ComputeHash(Encoding.ASCII.GetBytes(accessToken));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2", CultureInfo.InvariantCulture));
                }
                return builder.ToString();
            }
        }
    }
}