﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
//
// Runtime Version: 4.0.30319.42000
// Microsoft.VisualStudio.TextTemplating: 15.0
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Applicative {
    using System;

    using FsCheck.Xunit;
    using Xunit;

    // T4: EmitMonadCore().
    public static partial class FallibleFacts {
        internal sealed class tAttribute : FactAttribute {
            public tAttribute(string description) : base() {
                DisplayName = nameof(Fallible) + " - " + description;
            }
        }

        internal sealed class TAttribute : TheoryAttribute {
            public TAttribute(string description) : base() {
                DisplayName = nameof(Fallible) + " - " + description;
            }
        }

        internal sealed class qAttribute : PropertyAttribute {
            public qAttribute(string description) : base() {
                DisplayName = nameof(Fallible) + " - " + description;
            }
        }
    }

#if !NO_INTERNALS_VISIBLE_TO

    // Provides tests for Fallible<T>.
    // T4: EmitMonadGuards().
    public static partial class FallibleFacts {
        #region Repeat()

        [t("Repeat() guards.")]
        public static void Repeat0() {
            var source = Fallible<int>.η(1);

            Assert.Throws<ArgumentOutOfRangeException>("count", () => Fallible.Repeat(source, -1));
        }

        #endregion

        #region Zip()

        [t("Zip() guards.")]
        public static void Zip0() {
            var first = Fallible<int>.η(1);
            var second = Fallible<int>.η(2);
            var third = Fallible<int>.η(3);
            var fourth = Fallible<int>.η(4);
            var fifth = Fallible<int>.η(5);
            Func<int, int, int> zipper2 = null;
            Func<int, int, int, int> zipper3 = null;
            Func<int, int, int, int, int> zipper4 = null;
            Func<int, int, int, int, int, int> zipper5 = null;

            // Extension method.
            Assert.Throws<ArgumentNullException>("zipper", () => first.Zip(second, zipper2));
            Assert.Throws<ArgumentNullException>("zipper", () => first.Zip(second, third, zipper3));
            Assert.Throws<ArgumentNullException>("zipper", () => first.Zip(second, third, fourth, zipper4));
            Assert.Throws<ArgumentNullException>("zipper", () => first.Zip(second, third, fourth, fifth, zipper5));
            // Static method.
            Assert.Throws<ArgumentNullException>("zipper", () => FallibleExtensions.Zip(first, second, zipper2));
            Assert.Throws<ArgumentNullException>("zipper", () => FallibleExtensions.Zip(first, second, third, zipper3));
            Assert.Throws<ArgumentNullException>("zipper", () => FallibleExtensions.Zip(first, second, third, fourth, zipper4));
            Assert.Throws<ArgumentNullException>("zipper", () => FallibleExtensions.Zip(first, second, third, fourth, fifth, zipper5));
        }

        #endregion

        #region Select()

        [t("Select() guards.")]
        public static void Select0() {
            var source = Fallible<int>.η(1);
            Func<int, long> selector = null;

            Assert.Throws<ArgumentNullException>("selector", () => source.Select(selector));
            Assert.Throws<ArgumentNullException>("selector", () => FallibleExtensions.Select(source, selector));
        }

        #endregion

        #region SelectMany()

        [t("SelectMany() guards.")]
        public static void SelectMany0() {
            var source = Fallible<short>.η(1);
            var middle = Fallible<int>.η(2);
            Func<short, Fallible<int>> valueSelector = i => Fallible<int>.η(i);
            Func<short, int, long> resultSelector = (i, j) => i + j;

            // Extension method.
            Assert.Throws<ArgumentNullException>("selector", () => source.SelectMany(null, resultSelector));
            Assert.Throws<ArgumentNullException>("resultSelector", () => source.SelectMany(valueSelector, (Func<short, int, long>)null));
            // Static method.
            Assert.Throws<ArgumentNullException>("selector", () => FallibleExtensions.SelectMany(source, null, resultSelector));
            Assert.Throws<ArgumentNullException>("resultSelector", () => FallibleExtensions.SelectMany(source, valueSelector, (Func<short, int, long>)null));
        }

        #endregion

    }

#endif

#if !NO_INTERNALS_VISIBLE_TO

    // Provides tests for Fallible<T>: functor, monoid and monad laws.
    // T4: EmitMonadRules().
    public static partial class FallibleFacts {
        #region Functor Rules

        [q("The identity map is a fixed point for Select() (first functor rule).")]
        public static bool Select01(int arg) {
            var m = Fallible<int>.η(arg);

            // fmap id  ==  id
            var left = m.Select(x => x);
            var right = m;

            return left.Equals(right);
        }

        [q("Select() preserves the composition operator (second functor rule).")]
        public static bool Select02(short arg0, int arg1, long arg2) {
            var m = Fallible<short>.η(arg0);
            Func<short, int> g = x => arg1 * x;
            Func<int, long> f = x => arg2 * x;

            // fmap (f . g)  ==  fmap f . fmap g
            var left = m.Select(val => f(g(val)));
            var right = m.Select(g).Select(f);

            return left.Equals(right);
        }

        #endregion

        #region Monad Rules

        [q("Of() is a left identity for Bind() (first monad rule).")]
        public static bool Of01(int arg0, float arg1) {
            Func<int, Fallible<float>> f = x => Fallible<float>.η(arg1 * x);

            // return a >>= k  ==  k a
            var left = Fallible<int>.η(arg0).Bind(f);
            var right = f(arg0);

            return left.Equals(right);
        }

        [q("Of() is a left identity for Compose() (first monad rule).")]
        public static bool Of02(int arg0, float arg1) {
            Func<int, Fallible<int>> of = Fallible<int>.η;
            Func<int, Fallible<float>> f = x => Fallible<float>.η(arg1 * x);

            // return >=> g  ==  g
            var left = of.Compose(f).Invoke(arg0);
            var right = f(arg0);

            return left.Equals(right);
        }

        [q("Of() is a right identity for Bind() (second monad rule).")]
        public static bool Of03(int arg0) {
            var m = Fallible<int>.η(arg0);

            // m >>= return  ==  m
            var left = m.Bind(Fallible<int>.η);
            var right = m;

            return left.Equals(right);
        }

        [q("Of() is a right identity for Compose() (second monad rule).")]
        public static bool Of04(int arg0, float arg1) {
            Func<int, Fallible<float>> f = x => Fallible<float>.η(arg1 * x);

            // f >=> return  ==  f
            var left = f.Compose(Fallible<float>.η).Invoke(arg0);
            var right = f(arg0);

            return left.Equals(right);
        }

        [q("Bind() is associative (third monad rule).")]
        public static bool Bind01(short arg0, int arg1, long arg2) {
            var m = Fallible<short>.η(arg0);

            Func<short, Fallible<int>> f = x => Fallible<int>.η(arg1 * x);
            Func<int, Fallible<long>> g = x => Fallible<long>.η(arg2 * x);

            // m >>= (\x -> f x >>= g)  ==  (m >>= f) >>= g
            var left = m.Bind(f).Bind(g);
            var right = m.Bind(val => f(val).Bind(g));

            return left.Equals(right);
        }

        [q("Compose() is associative (third monad rule).")]
        public static bool Compose01(short arg0, int arg1, long arg2, double arg3) {
            Func<short, Fallible<int>> f = x => Fallible<int>.η(arg1 * x);
            Func<int, Fallible<long>> g = x => Fallible<long>.η(arg2 * x);
            Func<long, Fallible<double>> h = x => Fallible<double>.η(arg3 * x);

            // f >=> (g >=> h)  ==  (f >=> g) >=> h
            var left = f.Compose(g.Compose(h)).Invoke(arg0);
            var right = f.Compose(g).Compose(h).Invoke(arg0);

            return left.Equals(right);
        }

        #endregion
    }

#endif
}

