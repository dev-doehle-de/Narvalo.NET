﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

using Serilog.Core;
using Serilog.Events;

namespace Narvalo.Serilog
{
    using System;
    using System.Web;
    using Narvalo;

    [CLSCompliant(false)]
    public sealed class HttpLogEventEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            Require.NotNull(logEvent, "logEvent");
            Require.NotNull(propertyFactory, "propertyFactory");

            if (HttpContext.Current == null) {
                return;
            }

            var req = HttpContext.Current.Request;

            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Domain", req.Url.Host));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("RawUrl", req.RawUrl));

            if (req.UrlReferrer != null) {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UrlReferrer", req.UrlReferrer.ToString()));
            }
            
            if (!String.IsNullOrEmpty(req.UserHostAddress)) {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserHostAddress", req.UserHostAddress));
            }
            
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserAgent", req.UserAgent));
        }
    }
}