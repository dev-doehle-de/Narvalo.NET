﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Edu.Comparisons
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    using Narvalo.Diagnostics.Benchmarking;

    [BenchmarkComparison(100000, DisplayName = "Suppression des diacritiques.")]
    public static class RemoveDiacriticsComparison
    {
        // \p{Mn} or \p{Non_Spacing_Mark}:
        //   a character intended to be combined with another 
        //   character without taking up extra space 
        //   (e.g. accents, umlauts, etc.). 
        private static readonly Regex s_NonSpacingMarkRegex = new Regex(@"\p{Mn}", RegexOptions.Compiled);

        public static IEnumerable<string> GenerateTestData()
        {
            int[] lengths = new int[] { 10, 100 };

            var rnd = new Random();

            return from l in lengths select RandomString.GenerateUnicodeString(l, rnd);
        }

        [BenchmarkComparative(DisplayName = "Expression rationnelle.")]
        public static void Regex(string value)
        {
            Regex_(value);
        }

        [BenchmarkComparative(DisplayName = "Caractères traités pas à pas.")]
        public static void ForLoop(string value)
        {
            ForLoop_(value);
        }

        private static string Regex_(string value)
        {
            string formD = value.Normalize(NormalizationForm.FormD);

            if (formD != null)
            {
                return s_NonSpacingMarkRegex.Replace(formD, String.Empty);
            }
            else
            {
                return String.Empty;
            }
        }

        private static string ForLoop_(string value)
        {
            string formD = value.Normalize(NormalizationForm.FormD);

            var sb = new StringBuilder();

            for (int i = 0; i < formD.Length; i++)
            {
                char c = formD[i];

                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
