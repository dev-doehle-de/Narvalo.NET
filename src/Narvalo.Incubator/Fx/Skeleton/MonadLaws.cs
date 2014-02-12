﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx.Skeleton
{
    static class MonadLaws
    {
        static bool FirstLaw<X, Y>(Kunc<X, Y> f, X value)
        {
            return Monad.Return(value).Bind(f) == f(value);
        }

        static bool SecondLaw<X>(Monad<X> m)
        {
            return m.Bind(Monad.Return) == m;
        }

        static bool ThirdLaw<X, Y, Z>(Kunc<X, Y> g, Kunc<Y, Z> f, Monad<X> m)
        {
            return m.Bind(g).Bind(f) == m.Bind(_ => g(_).Bind(f));
            //return Bind(f, Bind(g, m)) == Bind(_ => Bind(f, g(_)), m);
        }

        static bool LeftIdentity<X, Y>(Kunc<X, Y> f, X value)
        {
            Kunc<X, X> id = _ => Monad.Return(_);
            return id.Compose(f).Invoke(value) == f(value);
            //return Compose(Monad.Return, f, value) == f(value);
        }

        static bool RightIdentity<X, Y>(Kunc<X, Y> f, X value)
        {
            return f.Compose(Monad.Return).Invoke(value) == f(value);
            //return Compose(f, Monad.Return, value) == f(value);
        }

        static bool Associativity<X, Y, Z, T>(
            Kunc<X, Y> f,
            Kunc<Y, Z> g,
            Kunc<Z, T> h,
            X value)
        {
            return f.Compose(g).Compose(h).Invoke(value)
                == f.Compose(g.Compose(h)).Invoke(value);

            //return Compose(_ => Compose(f, g, _), h, value)
            //    == Compose(f, _ => Compose(g, h, _), value);
        }

        //public static Monad<TResult> Compose<TSource, TMiddle, TResult>(
        //    Kunc<TSource, TMiddle> kunA,
        //    Kunc<TMiddle, TResult> kunB,
        //    TSource value)
        //{
        //    return kunA.Compose(kunB).Invoke(value);
        //}
    }
}
