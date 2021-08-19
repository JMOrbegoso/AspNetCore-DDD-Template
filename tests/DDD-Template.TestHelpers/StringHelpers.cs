using System;
using System.Linq;

namespace DDD_Template.TestHelpers
{
    public static class StringHelpers
    {
        public static string RandomStringGenerator(int length)
        {
            if (length < 0)
                throw new ArgumentException("Length is a negative number.");

            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomStringGenerator(int minLength, int maxLength)
        {
            if (minLength < 0)
                throw new ArgumentException("MinLength is a negative number.");

            if (maxLength < 0)
                throw new ArgumentException("MaxLength is a negative number.");

            if (maxLength < minLength)
                throw new ArgumentException("MinLength is greater than MaxLength.");

            var random = new Random();
            var length = random.Next(minLength, maxLength);
            return RandomStringGenerator(length);
        }
    }
}