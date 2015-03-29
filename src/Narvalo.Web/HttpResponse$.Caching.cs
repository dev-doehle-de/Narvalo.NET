﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Web;

    public static partial class HttpResponseExtensions
    {
        public static void NoCache(this HttpResponse @this)
        {
            Require.Object(@this);

            @this.Cache.SetCacheability(HttpCacheability.NoCache);
        }

        public static void PubliclyCacheFor(this HttpResponse @this, int days, int hours, int minutes)
        {
            Acknowledge.Object(@this);

            @this.PubliclyCacheFor(new TimeSpan(days, hours, minutes, 0));
        }

        public static void PubliclyCacheFor(this HttpResponse @this, TimeSpan duration)
        {
            Acknowledge.Object(@this);

            @this.CacheFor(duration, HttpCacheability.Public);
        }

        public static void PrivatelyCacheFor(this HttpResponse @this, int days, int hours, int minutes)
        {
            Acknowledge.Object(@this);

            @this.PrivatelyCacheFor(new TimeSpan(days, hours, minutes, 0));
        }

        public static void PrivatelyCacheFor(this HttpResponse @this, TimeSpan duration)
        {
            Acknowledge.Object(@this);

            // REVIEW: Utiliser HttpCacheability.ServerAndPrivate ?
            @this.CacheFor(duration, HttpCacheability.Private);
        }

        public static void CacheFor(this HttpResponse @this, TimeSpan duration, HttpCacheability cacheability)
        {
            Acknowledge.Object(@this);

            @this.CacheFor(duration, cacheability, HttpVersions.All);
        }

        public static void CacheFor(this HttpResponse @this, TimeSpan duration, HttpCacheability cacheability, HttpVersions versions)
        {
            Require.Object(@this);

            @this.Cache.SetCacheability(cacheability);

            // En-tête HTTP 1.0
            if (versions.Contains(HttpVersions.HttpV10))
            {
                // REVIEW: Now ou UtcNow ?
                @this.Cache.SetExpires(DateTime.UtcNow.Add(duration));
            }

            // En-tête HTTP 1.1
            if (versions.Contains(HttpVersions.HttpV11))
            {
                @this.Cache.SetMaxAge(duration);
                @this.Cache.AppendCacheExtension("must-revalidate, proxy-revalidate");
            }

            // REVIEW: Now ou UtcNow ?
            @this.Cache.SetLastModified(DateTime.Now);
        }
    }
}
