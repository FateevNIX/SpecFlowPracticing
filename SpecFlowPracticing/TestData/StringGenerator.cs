using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowPracticing.TestData
{
    public class StringGenerator
    {
        public static string RandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

           return new string(stringChars) + "@mail.com";
        }
    }
}
