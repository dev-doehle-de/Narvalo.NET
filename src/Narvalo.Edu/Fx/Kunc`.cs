﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Edu.Fx
{
    delegate Monad<T> Kunc<T>();

    delegate Monad<TResult> Kunc<in T, TResult>(T arg);

    delegate Monad<TResult> Kunc<in T1, in T2, TResult>(T1 arg1, T2 arg2);
}
