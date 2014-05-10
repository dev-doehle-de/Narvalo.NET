﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.Windows.Forms
{
    using System.Windows.Forms;
    using Narvalo.Mvp.PresenterBinding;

    public sealed class FormsPresenterBinder : PresenterBinder
    {
        readonly IMessageBus _messageBus;

        public FormsPresenterBinder(
            Form form,
            IPresenterDiscoveryStrategy presenterDiscoveryStrategy,
            IPresenterFactory presenterFactory,
            ICompositeViewFactory compositeViewFactory,
            IMessageBus messageBus)
            : base(
                new[] { form },
                presenterDiscoveryStrategy,
                presenterFactory,
                compositeViewFactory)
        {
            Require.NotNull(messageBus, "messageBus");

            _messageBus = messageBus;
        }

        protected override void OnPresenterCreated(PresenterCreatedEventArgs args)
        {
            var presenter = args.Presenter as IFormPresenter;
            if (presenter != null) {
                presenter.Messages = _messageBus;

                presenter.OnBindingComplete();
            }

            base.OnPresenterCreated(args);
        }
    }
}
