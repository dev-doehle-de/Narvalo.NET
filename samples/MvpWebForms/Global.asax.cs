﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace MvpWebForms
{
    using System;
    using System.Diagnostics;
    using System.Web;

    using Narvalo.Mvp.PresenterBinding;
    using Narvalo.Mvp.Web;
    using Narvalo.Mvp.Web.Core;

    public class Global : HttpApplication
    {
        public void Application_Start(object sender, EventArgs e)
        {
            Trace.Listeners.Add(new WebPageTraceListener());

            var presenterDiscoveryStrategy
                = new AspNetPresenterDiscoveryStrategy(
                    AspNetPresenterDiscoveryStrategy.DefaultViewSuffixes,
                    new[] { "MvpWebForms.Presenters.{presenter}" },
                    enableCache: true);

            new MvpBootstrapper()
                .DiscoverPresenter.With(new AttributedPresenterDiscoveryStrategy())
                .DiscoverPresenter.With(presenterDiscoveryStrategy)
                .InitializePlatform();
        }
    }
}
