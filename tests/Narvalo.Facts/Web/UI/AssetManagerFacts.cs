﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web.UI
{
    using System.Configuration;
    using System.Configuration.Provider;

    using Narvalo.Web.Configuration;
    using Xunit;

    // WARNING: When testing a static property, be sure to call AssetManager.ResetInternal() before.
    public static partial class AssetManagerFacts
    {
        #region Provider

        [Fact]
        public static void Provider_DoesNotThrow_ForMissingAssetSection()
        {
            // Arrange
            AssetManager.ResetInternal();

            // Act
            var provider = AssetManager.Provider;
        }

        [Fact]
        public static void Provider_IsDefaultAssetProvider_ForMissingAssetSection()
        {
            // Arrange
            AssetManager.ResetInternal();

            // Act
            var provider = AssetManager.Provider;

            // Assert
            Assert.IsType<DefaultAssetProvider>(provider);
        }

        #endregion

        #region Providers

        [Fact]
        public static void Providers_DoesNotThrow_ForMissingAssetSection()
        {
            // Arrange
            AssetManager.ResetInternal();

            // Act
            var providers = AssetManager.Providers;
        }

        [Fact]
        public static void Providers_OnlyContainsDefaultAssetProvider_ForMissingAssetSection()
        {
            // Arrange
            AssetManager.ResetInternal();

            // Act
            var providers = AssetManager.Providers;

            // Assert
            Assert.Equal(1, providers.Count);
            Assert.IsType<DefaultAssetProvider>(providers[DefaultAssetProvider.InternalCustomDefaultName]);
        }

        #endregion

        #region InitializeInternal()

        [Fact]
        public static void InitializeInternal_ThrowsProviderException_ForNullDefaultProviderProperty()
        {
            // Arrange
            var section = new AssetSection();
           section.DefaultProvider = null;

            // Act & Assert
            Assert.Throws<ProviderException>(() => AssetManager.InitializeInternal(section));
        }

        [Fact]
        public static void InitializeInternal_ThrowsConfigurationErrorsException_ForMissingDefaultProviderProperty()
        {
            // Arrange
            var section = new AssetSection();

            // Act & Assert
            Assert.Throws<ConfigurationErrorsException>(() => AssetManager.InitializeInternal(section));
        }

        [Fact]
        public static void InitializeInternal_ThrowsConfigurationErrorsException_ForInvalidDefaultProviderProperty()
        {
            // Arrange
            var section = new AssetSection();
            section.DefaultProvider = "InvalidProvider";

            // Act & Assert
            Assert.Throws<ConfigurationErrorsException>(() => AssetManager.InitializeInternal(section));
        }

        #endregion
    }
}
