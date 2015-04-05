﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web.UI
{
    using System;
    using System.Collections.Specialized;
    using System.Diagnostics.Contracts;
    using System.Web;

    using Narvalo.Collections;
    using Narvalo.Fx;
    using Narvalo.Web.Properties;

    public sealed class LocalAssetProvider : AssetProviderBase
    {
        private const string FONTS_PATH_KEY = "fontsPath";
        private const string IMAGES_PATH_KEY = "imagesPath";
        private const string SCRIPTS_PATH_KEY = "scriptsPath";
        private const string STYLES_PATH_KEY = "stylesPath";

        private string _fontsPath;
        private string _imagesPath;
        private string _scriptsPath;
        private string _stylesPath;

        public LocalAssetProvider()
        {
            DefaultName = "LocalAssetProvider";
            DefaultDescription = Strings_Web.LocalAssetProvider_Description;
        }

        public override Uri GetFontUri(string relativePath)
        {
            // Here we can be sure that _fontsPath is not null or empty; cf. Initialize().
            Contract.Assume(_fontsPath != null);

            return MakeUri_(_fontsPath, relativePath);
        }

        public override Uri GetImageUri(string relativePath)
        {
            // Here we can be sure that _fontsPath is not null or empty; cf. Initialize().
            Contract.Assume(_imagesPath != null);

            return MakeUri_(_imagesPath, relativePath);
        }

        public override Uri GetScriptUri(string relativePath)
        {
            // Here we can be sure that _fontsPath is not null or empty; cf. Initialize().
            Contract.Assume(_scriptsPath != null);

            return MakeUri_(_scriptsPath, relativePath);
        }

        public override Uri GetStyleUri(string relativePath)
        {
            // Here we can be sure that _fontsPath is not null or empty; cf. Initialize().
            Contract.Assume(_stylesPath != null);

            return MakeUri_(_stylesPath, relativePath);
        }

        protected override void InitializeCustom(NameValueCollection config)
        {
            InitializeCustomInternal(config);

            var fontsPath = config.MayGetSingle(FONTS_PATH_KEY);
            var imagesPath = config.MayGetSingle(IMAGES_PATH_KEY);
            var scriptsPath = config.MayGetSingle(SCRIPTS_PATH_KEY);
            var stylesPath = config.MayGetSingle(STYLES_PATH_KEY);

            // FIXME: If none after normalization, throw.
            _fontsPath = fontsPath.Select(NormalizeAppRelativePath).ValueOrElse("~/assets/fonts/");
            _imagesPath = imagesPath.Select(NormalizeAppRelativePath).ValueOrElse("~/assets/img/");
            _scriptsPath = scriptsPath.Select(NormalizeAppRelativePath).ValueOrElse("~/assets/js/");
            _stylesPath = stylesPath.Select(NormalizeAppRelativePath).ValueOrElse("~/assets/css/");

            if (fontsPath.IsSome) { config.Remove(FONTS_PATH_KEY); }
            if (imagesPath.IsSome) { config.Remove(IMAGES_PATH_KEY); }
            if (scriptsPath.IsSome) { config.Remove(SCRIPTS_PATH_KEY); }
            if (stylesPath.IsSome) { config.Remove(STYLES_PATH_KEY); }
        }

        // FIXME: If any value is invalid, return null.
        internal static string NormalizeAppRelativePath(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            else
            {
                return value;
            }
        }

        private static Uri MakeUri_(string baseIntermediatePath, string relativePath)
        {
            Require.NotNull(relativePath, "relativePath");
            Contract.Requires(baseIntermediatePath != null);
            Contract.Requires(baseIntermediatePath.Length != 0);
            Contract.Ensures(Contract.Result<Uri>() != null);

            // NB: If basePath or relativePath is null or empty, VirtualPathUtility.Combine will throw,
            // which is of course exactly what we want.
            var uriString = VirtualPathUtility.ToAbsolute(
                relativePath.Length == 0 ? baseIntermediatePath : VirtualPathUtility.Combine(baseIntermediatePath, relativePath));

            return new Uri(uriString, UriKind.Relative);
        }
    }
}