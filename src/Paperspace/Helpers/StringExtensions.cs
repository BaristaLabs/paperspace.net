namespace Paperspace
{
    using System;

    internal static class StringExtensions
    {
        public static Uri FormatUri(this string pattern)
        {
            Ensure.ArgumentNotNullOrEmptyString(pattern, nameof(pattern));

            return new Uri(pattern, UriKind.Relative);
        }
    }
}
