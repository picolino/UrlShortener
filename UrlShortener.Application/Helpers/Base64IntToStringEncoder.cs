using System.Linq;
using System.Text;

namespace UrlShortener.Application.Helpers
{
    internal static class Base64IntToStringEncoder
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly int Base = Alphabet.Length;

        internal static string Encode(int num)
        {
            if (num == 0) return Alphabet[0].ToString();

            var stringBuilder = new StringBuilder();

            while (num > 0)
            {
                stringBuilder.Insert(0, Alphabet[num % Base]);
                num /= Base;
            }

            return stringBuilder.ToString();
        }

        internal static int Decode(string str)
        {
            return str.Aggregate(0, (current, c) => current * Base + Alphabet.IndexOf(c));
        }
    }
}