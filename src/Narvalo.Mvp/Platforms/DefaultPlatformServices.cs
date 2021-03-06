﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.Platforms
{
    using System;

    using Narvalo.Mvp.PresenterBinding;
    using Narvalo.Mvp.Properties;

    // FIXME: This whole business to ensure delayed initialization of the properties was
    // most certainly one of the worst idea I ever had.
    public partial class DefaultPlatformServices : IPlatformServices
    {
        private Func<ICompositeViewFactory> _compositeViewFactoryThunk
           = () => new CompositeViewFactory();

        private Func<IMessageCoordinatorFactory> _messageCoordinatorFactoryThunk
           = () => new MessageCoordinatorFactory();

        private Func<IPresenterDiscoveryStrategy> _presenterDiscoveryStrategyThunk
           = () => new AttributedPresenterDiscoveryStrategy();

        private Func<IPresenterFactory> _presenterFactoryThunk
           = () => new PresenterFactory();

        private ICompositeViewFactory _compositeViewFactory;
        private IMessageCoordinatorFactory _messageCoordinatorFactory;
        private IPresenterDiscoveryStrategy _presenterDiscoveryStrategy;
        private IPresenterFactory _presenterFactory;

        public ICompositeViewFactory CompositeViewFactory
        {
            get
            {
                if (_compositeViewFactory == null)
                {
                    _compositeViewFactory = _compositeViewFactoryThunk();

                    if (_compositeViewFactory == null)
                    {
                        throw new InvalidOperationException(
                            Strings.DefaultPlatformServices_InvalidCompositeViewFactoryThunk);
                    }
                }

                return _compositeViewFactory;
            }
        }

        public IMessageCoordinatorFactory MessageCoordinatorFactory
        {
            get
            {
                if (_messageCoordinatorFactory == null)
                {
                    _messageCoordinatorFactory = _messageCoordinatorFactoryThunk();

                    if (_messageCoordinatorFactory == null)
                    {
                        throw new InvalidOperationException(
                            Strings.DefaultPlatformServices_InvalidMessageCoordinatorFactoryThunk);
                    }
                }

                return _messageCoordinatorFactory;
            }
        }

        public IPresenterDiscoveryStrategy PresenterDiscoveryStrategy
        {
            get
            {
                if (_presenterDiscoveryStrategy == null)
                {
                    _presenterDiscoveryStrategy = _presenterDiscoveryStrategyThunk();

                    if (_presenterDiscoveryStrategy == null)
                    {
                        throw new InvalidOperationException(
                            Strings.DefaultPlatformServices_InvalidPresenterDiscoveryStrategyThunk);
                    }
                }

                return _presenterDiscoveryStrategy;
            }
        }

        public IPresenterFactory PresenterFactory
        {
            get
            {
                if (_presenterFactory == null)
                {
                    _presenterFactory = _presenterFactoryThunk();

                    if (_presenterFactory == null)
                    {
                        throw new InvalidOperationException(
                            Strings.DefaultPlatformServices_InvalidPresenterFactoryThunk);
                    }
                }

                return _presenterFactory;
            }
        }

        protected void SetMessageCoordinatorFactory(Func<IMessageCoordinatorFactory> thunk)
        {
            Require.NotNull(thunk, nameof(thunk));

            _messageCoordinatorFactoryThunk = thunk;
        }

        protected void SetCompositeViewFactory(Func<ICompositeViewFactory> thunk)
        {
            Require.NotNull(thunk, nameof(thunk));

            _compositeViewFactoryThunk = thunk;
        }

        protected void SetPresenterDiscoveryStrategy(Func<IPresenterDiscoveryStrategy> thunk)
        {
            Require.NotNull(thunk, nameof(thunk));

            _presenterDiscoveryStrategyThunk = thunk;
        }

        protected void SetPresenterFactory(Func<IPresenterFactory> thunk)
        {
            Require.NotNull(thunk, nameof(thunk));

            _presenterFactoryThunk = thunk;
        }
    }
}
