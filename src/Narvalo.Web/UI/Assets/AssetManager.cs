﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web.UI.Assets
{
    using System;
    using System.Configuration;
    using System.Configuration.Provider;
    using System.Web.Configuration;
    using Narvalo.Web.Configuration;

    public static class AssetManager
    {
        static readonly object Lock_ = new Object();

        static AssetProviderBase Provider_;
        static AssetProviderCollection Providers_;

        static bool InitializedDefaultProvider_ = false;
        static bool InitializedProviders_ = false;

        public static AssetProviderBase Provider
        {
            get
            {
                EnsureInitialized_();
                return Provider_;
            }
        }

        public static AssetProviderCollection Providers
        {
            get
            {
                EnsureInitialized_();
                return Providers_;
            }
        }

        public static Uri ImageBase { get { return Provider.GetImage(String.Empty); } }

        public static Uri ScriptBase { get { return Provider.GetScript(String.Empty); } }

        public static Uri StyleBase { get { return Provider.GetStyle(String.Empty); } }

        public static Uri GetImage(string relativePath)
        {
            Require.NotNullOrEmpty(relativePath, "relativePath");
            return Provider.GetImage(relativePath);
        }

        public static Uri GetScript(string relativePath)
        {
            Require.NotNullOrEmpty(relativePath, "relativePath");
            return Provider.GetScript(relativePath);
        }

        public static Uri GetStyle(string relativePath)
        {
            Require.NotNullOrEmpty(relativePath, "relativePath");
            return Provider.GetStyle(relativePath);
        }

        static void EnsureInitialized_()
        {
            if (InitializedProviders_ && InitializedDefaultProvider_) {
                return;
            }

            lock (Lock_) {
                if (InitializedProviders_ && InitializedDefaultProvider_) {
                    return;
                }

                var section = NarvaloWebConfigurationManager.AssetSection;

                InitProviders_(section);
                InitDefaultProvider_(section);
            }
        }

        static void InitProviders_(AssetSection section)
        {
            if (InitializedProviders_) {
                return;
            }

            var tmpProviders = new AssetProviderCollection();
            if (section.Providers != null) {
                ProvidersHelper.InstantiateProviders(section.Providers, tmpProviders, typeof(AssetProviderBase));
                tmpProviders.SetReadOnly();
            }

            Providers_ = tmpProviders;
            InitializedProviders_ = true;
        }

        static void InitDefaultProvider_(AssetSection section)
        {
            if (InitializedDefaultProvider_) {
                return;
            }

            if (section.DefaultProvider == null) {
                throw new ConfigurationErrorsException(
                    Strings_Web.AssetManager_DefaultProviderNotConfigured,
                    section.ElementInformation.Properties["providers"].Source,
                    section.ElementInformation.Properties["providers"].LineNumber);
            }

            Provider_ = Providers_[section.DefaultProvider];

            if (Provider_ == null) {
                throw new ProviderException(Strings_Web.AssetManager_DefaultProviderNotFound);
            }

            InitializedDefaultProvider_ = true;
        }
    }
}
