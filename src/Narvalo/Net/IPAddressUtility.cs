﻿namespace Narvalo.Net
{
    using System.Net;
    using Narvalo.Fx;

    public static class IPAddressUtility
    {
        public static Maybe<IPAddress> ToIPAddress(string value)
        {
            return Narvalo.MayParse.MayParseHelper<IPAddress>(
                value,
                (string val, out IPAddress result) => IPAddress.TryParse(val, out result)
            );
        }
    }
}