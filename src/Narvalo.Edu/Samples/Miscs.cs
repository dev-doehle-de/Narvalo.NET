﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Edu.Collections.Recursion
{
    using System;
    using Narvalo.Edu.Monads;

    class Mu
    {
        public Monad<Mu> Out { get; private set; }

        public Mu(Monad<Mu> f)
        {
            this.Out = f;
        }

        public TResult Cata<TResult>(Func<Monad<TResult>, TResult> phi)
        {
            return phi(Out.Select(_ => _.Cata(phi)));
        }

        public static Mu Ana<TResult>(Func<TResult, Monad<TResult>> psi, TResult seed)
        {
            return new Mu(psi(seed).Select(_ => Mu.Ana(psi, _)));
        }

        public static T2 Hylo<T1, T2>(
            Func<T1, Monad<T1>> psi,
            Func<Monad<T2>, T2> phi,
            T1 seed)
        {
            return Mu.Ana(psi, seed).Cata(phi);
        }
    }
}
