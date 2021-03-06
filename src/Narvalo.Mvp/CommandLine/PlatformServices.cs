﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.CommandLine
{
    using Narvalo.Mvp.Platforms;

    public static class PlatformServices
    {
        private static readonly IPlatformServices s_Default = new DefaultPlatformServices_();

        private static readonly PlatformServicesVirtualProxy s_Instance
            = new PlatformServicesVirtualProxy(() => s_Default);

        public static IPlatformServices Default => s_Default;

        public static IPlatformServices Current
        {
            get { return s_Instance; }
            set { s_Instance.Reset(value); }
        }

        private sealed class DefaultPlatformServices_ : DefaultPlatformServices
        {
            public DefaultPlatformServices_()
            {
                SetPresenterDiscoveryStrategy(
                    () => new DefaultPresenterDiscoveryStrategy());
            }
        }
    }
}
