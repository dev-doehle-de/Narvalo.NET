﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web.Mvp.Core
{
    using System.Collections.Generic;
    using System.Web;
    using Narvalo.Mvp;
    using Narvalo.Mvp.PresenterBinding;

    public sealed class HttpPresenterBinder : PresenterBinder
    {
        readonly HttpContext _context;

        public HttpPresenterBinder(
            IEnumerable<object> hosts,
            HttpContext context,
            IPresenterDiscoveryStrategy presenterDiscoveryStrategy,
            IPresenterFactory presenterFactory,
            ICompositeViewFactory compositeViewFactory,
            IMessageCoordinator messageCoordinator)
            : base(
                hosts,
                presenterDiscoveryStrategy,
                presenterFactory,
                compositeViewFactory,
                messageCoordinator)
        {
            Require.NotNull(context, "context");

            _context = context;
        }

        protected override void OnPresenterCreated(PresenterCreatedEventArgs args)
        {
            var presenter = args.Presenter as Narvalo.Web.Internal.IHttpPresenter;
            if (presenter != null) {
                presenter.HttpContext = new HttpContextWrapper(_context);
            }

            base.OnPresenterCreated(args);
        }
    }
}