﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web.Semantic
{
    using System.Diagnostics.Contracts;
    using System.Globalization;

    public sealed class OpenGraphLocale
    {
        private readonly CultureInfo _culture;

        public OpenGraphLocale(CultureInfo culture)
        {
            Require.NotNull(culture, "culture");

            _culture = culture;
        }

        public CultureInfo Culture
        {
            get
            {
                Contract.Ensures(Contract.Result<CultureInfo>() != null);

                return _culture;
            }
        }

        public override string ToString()
        {
            return _culture.ToString().Replace('-', '_');
        }
    }
}
