﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web.UI.Assets
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration.Provider;
    using System.Diagnostics.CodeAnalysis;
    using Narvalo;
    using Narvalo.Collections;

    public sealed class RemoteAssetProvider : AssetProviderBase
    {
        Uri _baseUri;

        public RemoteAssetProvider() { }

        public override void Initialize(string name, NameValueCollection config)
        {
            Require.NotNull(config, "config");

            if (String.IsNullOrEmpty(name)) {
                name = "RemoteAssetProvider";
            }

            if (String.IsNullOrEmpty(config["description"])) {
                config.Remove("description");
                config.Add("description", "Narvalo remote asset provider.");
            }

            base.Initialize(name, config);

            // Initialisation du champs baseUri.
            _baseUri = config.MayGetSingle("baseUri")
                .Bind(_ => ParseTo.Uri(_, UriKind.RelativeOrAbsolute))
                .ValueOrThrow(() => new ProviderException("Missing or invalid config 'baseUri'."));
            config.Remove("baseUri");
        }

        public override Uri GetFont(string relativePath)
        {
            // WARNING: Ne pas utiliser "/font/", car si _baseUri contient déjà un chemin relatif, il sera ignoré.
            return MakeUri_("font/", relativePath);
        }

        public override Uri GetImage(string relativePath)
        {
            // WARNING: Ne pas utiliser "/img/", car si _baseUri contient déjà un chemin relatif, il sera ignoré.
            return MakeUri_("img/", relativePath);
        }

        public override Uri GetScript(string relativePath)
        {
            // WARNING: Ne pas utiliser "/js/", car si _baseUri contient déjà un chemin relatif, il sera ignoré.
            return MakeUri_("js/", relativePath);
        }

        public override Uri GetStyle(string relativePath)
        {
            // WARNING: Ne pas utiliser "/css/", car si _baseUri contient déjà un chemin relatif, il sera ignoré.
            return MakeUri_("css/", relativePath);
        }

        [SuppressMessage("Microsoft.Usage", "CA2234:PassSystemUriObjectsInsteadOfStrings", Justification = "Utiliser une URI serait contre productif.")]
        Uri MakeUri_(string basePath, string relativePath)
        {
            return new Uri(_baseUri, basePath + relativePath);
        }
    }
}