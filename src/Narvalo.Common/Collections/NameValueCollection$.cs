﻿namespace Narvalo.Collections
{
    using System;
    using System.Collections.Specialized;
    using Narvalo;

    /// <summary>
    /// Provides extension methods for <see cref="System.Collections.Specialized.NameValueCollection"/>.
    /// </summary>
    public static partial class NameValueCollectionExtensions
    {
        public static T? ParseValue<T>(this NameValueCollection @this, string name, Func<string, T?> parser) where T : struct
        {
            Require.Object(@this);

            return @this.MayGetValue(name).Map(parser).ValueOrDefault();
        }
    }
}
