using System;

namespace MarsRover.UserInteraction
{
    public static class StringExtensions
    {
        public static string TextAfter(this string value, string search)
        {
            return value.Substring(value.IndexOf(search, StringComparison.Ordinal) + search.Length);
        }

        public static string TextBefore(this string value, string search)
        {
            return value.Substring(0, value.IndexOf(search, StringComparison.Ordinal));
        }
    }
}