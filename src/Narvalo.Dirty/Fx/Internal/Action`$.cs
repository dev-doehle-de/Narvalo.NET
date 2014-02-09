﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx.Internal
{
    using System;

    static class ActionExtensions
    {
        public static Kunc<Unit, Unit> ToKunc(this Action @this)
        {
            return _ => { @this.Invoke(); return Monad.Unit; };
        }

        public static Kunc<TSource, Unit> ToKunc<TSource>(this Action<TSource> @this)
        {
            return _ => { @this.Invoke(_); return Monad.Unit; };
        }
    }
}
