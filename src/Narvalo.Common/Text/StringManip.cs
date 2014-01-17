﻿namespace Narvalo.Text
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Text;

    public static class StringManip
    {
        public static string RemoveDiacritics(string value)
        {
            Require.NotNull(value, "value");

            if (value.Length == 0) {
                return String.Empty;
            }

            var formD = value.Normalize(NormalizationForm.FormD);

            var sb = new StringBuilder();

            for (int i = 0; i < formD.Length; i++) {
                Char c = formD[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark) {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string Reverse(string value)
        {
            Require.NotNull(value, "value");

            if (value.Length == 0) {
                return String.Empty;
            }

            char[] arr = value.ToCharArray();
            Array.Reverse(arr);

            return new String(arr);
        }

        public static string StripCrLf(string value)
        {
            Require.NotNull(value, "value");

            if (value.Length == 0) {
                return String.Empty;
            }

            return value.Replace("\n", String.Empty).Replace("\r", String.Empty);
        }

        public static string Substring(string value, int startIndex, int length)
        {
            return Substring(value, startIndex, length, "...");
        }

        public static string Substring(string value, int startIndex, int length, string postfix)
        {
            Require.NotNull(value, "value");
            Require.GreaterThanOrEqualTo(startIndex, 0, "startIndex");
            Require.GreaterThanOrEqualTo(length, 1, "length");

            if (value.Length <= length) {
                // La chaîne d'origine est trop courte.
                return value;
            }
            else {
                if (value.Length < startIndex || value.Length < startIndex + length) {
                    // L'index de début est trop haut
                    // ou l'index de fin est trop haut.
                    return String.Format(
                        CultureInfo.CurrentCulture,
                        "{0}{1}",
                        value.Substring(value.Length - length, length - 1),
                        postfix);
                }
                else {
                    return String.Format(
                        CultureInfo.CurrentCulture,
                        "{0}{1}",
                        value.Substring(startIndex, length - 1),
                        postfix);
                }
            }
        }

        public static string Truncate(string value, int length)
        {
            return Truncate(value, length, "...");
        }

        public static string Truncate(string value, int length, string postfix)
        {
            Require.NotNull(value, "value");
            Require.GreaterThanOrEqualTo(length, 1, "length");

            if (value.Length <= length) {
                return value;
            }
            else {
                return String.Format(
                    CultureInfo.CurrentCulture,
                    "{0}{1}",
                    value.Substring(0, length - 1),
                    postfix);
            }
        }

        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "Sans cela la méthode ne remplirait pas sa fonction.")]
        public static string ToTitleCase(string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLowerInvariant());
        }
    }
}
