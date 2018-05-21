using System.Linq;

namespace CsdsLib
{
    public static class StringExtensions
    {
        public static string Reverse(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }

            var arr = s.ToCharArray();
            var head = 0;
            var tail = arr.Length - 1;

            while (head < tail)
            {
                var save = arr[head];
                arr[head] = arr[tail];
                arr[tail] = save;
                head++;
                tail--;
            }

            return new string(arr);
        }

        public static bool IsPalindrome(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            if (s.Length == 1)
            {
                return true;
            }

            var arr = s.ToLowerInvariant()
                .ToCharArray()
                .Where(char.IsLetterOrDigit)
                .ToArray();


            var head = 0;
            var tail = arr.Length - 1;

            while (head < tail)
            {
                if (arr[head] != arr[tail])
                {
                    return false;
                }

                head++;
                tail--;
            }

            return true;
        }
    }
}