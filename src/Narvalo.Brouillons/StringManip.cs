﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Text;

    public static class StringManip
    {
        // Cf. http://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net
        public static string RemoveDiacritics(string value)
        {
            Require.NotNull(value, "value");
            Contract.Ensures(Contract.Result<string>() != null);

            if (value.Length == 0)
            {
                return String.Empty;
            }

            var formD = value.Normalize(NormalizationForm.FormD);

            var sb = new StringBuilder();

            for (int i = 0; i < formD.Length; i++)
            {

                if (CharUnicodeInfo.GetUnicodeCategory(formD[i]) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(formD[i]);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
