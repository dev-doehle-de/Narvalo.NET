﻿namespace Playground
{
    using System;
    using System.Web;
    using Narvalo.Mvp.PresenterBinding;
    using Narvalo.Mvp.Web;
    using Narvalo.Mvp.Web.Core;

    public class Global : HttpApplication
    {
        public void Application_Start(object sender, EventArgs e)
        {
            var presenterDiscoveryStrategy
                = new AspNetConventionBasedPresenterDiscoveryStrategy(
                    AspNetConventionBasedPresenterDiscoveryStrategy.DefaultViewSuffixes,
                    new[] { "Playground.Presenters.{presenter}" },
                    enableCache: true);

            new MvpBootstrapper()
                .DiscoverPresenter.With(new AttributeBasedPresenterDiscoveryStrategy())
                .DiscoverPresenter.With(presenterDiscoveryStrategy)
                .Run();
        }
    }
}