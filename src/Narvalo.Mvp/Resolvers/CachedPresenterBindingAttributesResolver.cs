﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.Resolvers
{
    using System;
    using System.Collections.Generic;

    public sealed class CachedPresenterBindingAttributesResolver
        : IPresenterBindingAttributesResolver
    {
        readonly TypeKeyedResolverCache<IEnumerable<PresenterBindingAttribute>> _cache
           = new TypeKeyedResolverCache<IEnumerable<PresenterBindingAttribute>>();

        readonly IPresenterBindingAttributesResolver _inner;

        public CachedPresenterBindingAttributesResolver(IPresenterBindingAttributesResolver inner)
        {
            Require.NotNull(inner, "inner");

            _inner = inner;
        }

        public IEnumerable<PresenterBindingAttribute> Resolve(Type viewType)
        {
            return _cache.GetOrAdd(viewType, _inner.Resolve);
        }
    }
}