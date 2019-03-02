using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMySQLC969
{
    public static class StringExtension
    {
        // Extension method for strings that allows better truncatation.
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
        public static string ReplaceAt(this string input, int index1, int index2, char newChar1, char newChar2)
        {
            if (input == null)
            {
                throw new ArgumentNullException("Input issue. Please try again.");
            }
            char[] chars = input.ToCharArray();
            chars[index1] = newChar1;
            chars[index2] = newChar2;
            return new string(chars);
        }
    }
}
