﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.Resolvers
{
    using System;
    using System.Reflection.Emit;

    public partial interface IPresenterConstructorResolver
    {
        DynamicMethod Resolve(Type presenterType, Type viewType);
    }
}
