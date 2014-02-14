﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx.Skeleton
{
    static class Stubs
    {
        static readonly Kunc<Unit, Unit> Noop_ = _ => Monad.Unit;

        public static Kunc<Unit, Unit> Noop { get { return Noop_; } }
    }
}
