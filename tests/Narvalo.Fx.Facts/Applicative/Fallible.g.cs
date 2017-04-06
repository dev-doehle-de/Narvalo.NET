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
    using System.Linq;

    using FsCheck.Xunit;
    using Narvalo.Linq;
    using Xunit;

    // Provides tests for Fallible<T>.
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

        private sealed class DisposableObj : IDisposable {
            public DisposableObj() { }

            public bool WasDisposed { get; private set; }

            public void Dispose() {
                WasDisposed = true;
            }
        }
    }

#if !NO_INTERNALS_VISIBLE_TO

    // T4: EmitMonadGuards().
    public static partial class FallibleFacts {
        [t("Compose() guards.")]
        public static void Compose0() {
            Func<int, Fallible<int>> first = null;
            Func<int, Fallible<int>> second = i => Fallible<int>.η(1);

            Assert.Throws<ArgumentNullException>("this", () => first.Compose(second));
        }

        [t("Compose() guards.")]
        public static void ComposeBack0() {
            Func<int, Fallible<int>> first = i => Fallible<int>.η(1);
            Func<int, Fallible<int>> second = null;

            Assert.Throws<ArgumentNullException>("second", () => first.ComposeBack(second));
        }

        [t("Repeat() guards.")]
        public static void Repeat0() {
            var source = Fallible<int>.η(1);

            Assert.Throws<ArgumentOutOfRangeException>("count", () => Fallible.Repeat(source, -1));
        }

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

        [t("Select() guards.")]
        public static void Select0() {
            var source = Fallible<int>.η(1);
            Func<int, long> selector = null;

            Assert.Throws<ArgumentNullException>("selector", () => source.Select(selector));
            Assert.Throws<ArgumentNullException>("selector", () => FallibleExtensions.Select(source, selector));
        }

        [t("Using() guards.")]
        public static void Using0() {
            var source = Fallible<DisposableObj>.η(new DisposableObj());
            Func<DisposableObj, Fallible<int>> binder = null;
            Func<DisposableObj, int> selector = null;

            Assert.Throws<ArgumentNullException>("binder", () => source.Using(binder));
            Assert.Throws<ArgumentNullException>("binder", () => FallibleExtensions.Using(source, binder));

            Assert.Throws<ArgumentNullException>("selector", () => source.Using(selector));
            Assert.Throws<ArgumentNullException>("selector", () => FallibleExtensions.Using(source, selector));
        }

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

    }

#endif

#if !NO_INTERNALS_VISIBLE_TO

    // T4: EmitMonadTests().
    public static partial class FallibleFacts {
        [q("Repeat() repeats the enclosed value if any.")]
        public static bool Repeat01(int arg) {
            var source = Fallible<int>.η(arg);

            var result = Fallible.Repeat(source, 10);
            var seq = Enumerable.Repeat(arg, 10);

            var q = from x in result select Enumerable.SequenceEqual(x, seq);

            return q.Contains(true);
        }

        [q("Lift() is Select().")]
        public static bool Lift01(int arg0, long arg1) {
            Func<int, long> selector = i => arg1 * i;
            var selector1 = Fallible.Lift<int, long>(selector);

            var source = Fallible<int>.η(arg0);

            var left = selector1(source);
            var right = source.Select(selector);

            return left.Equals(right);
        }

        [q("Select() is Lift().")]
        public static bool Select01(int arg0, long arg1) {
            Func<int, long> selector = i => arg1 * i;
            var selector1 = Fallible.Lift<int, long>(selector);

            var source = Fallible<int>.η(arg0);

            var left = selector1(source);
            var right = FallibleExtensions.Select(source, selector);

            return left.Equals(right);
        }

        [q("Lift() is Zip() (1).")]
        public static bool Lift02(int arg0, int arg1, int arg2, int arg3) {
            Func<int, int, long> zipper = (i, j) => arg2 * i + arg3 * j;
            var zipper1 = Fallible.Lift<int, int, long>(zipper);

            var p0 = Fallible<int>.η(arg0);
            var p1 = Fallible<int>.η(arg1);

            var left = zipper1(p0, p1);
            var right = p0.Zip(p1, zipper);

            return left.Equals(right);
        }

        // NB: Lift01() but w/o using Zip as an extension method.
        [q("Zip() is Lift() (1).")]
        public static bool Zip02(int arg0, int arg1, int arg2, int arg3) {
            Func<int, int, long> zipper = (i, j) => arg2 * i + arg3 * j;
            var zipper1 = Fallible.Lift<int, int, long>(zipper);

            var p0 = Fallible<int>.η(arg0);
            var p1 = Fallible<int>.η(arg1);

            var left = zipper1(p0, p1);
            var right = FallibleExtensions.Zip(p0, p1, zipper);

            return left.Equals(right);
        }

        [q("Lift() is Zip() (2).")]
        public static bool Lift03(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5) {
            Func<int, int, int, long> zipper = (i, j, k) => arg3 * i + arg4 * j + arg5 * k;
            var zipper1 = Fallible.Lift<int, int, int, long>(zipper);

            var p0 = Fallible<int>.η(arg0);
            var p1 = Fallible<int>.η(arg1);
            var p2 = Fallible<int>.η(arg2);

            var left = zipper1(p0, p1, p2);
            var right = p0.Zip(p1, p2, zipper);

            return left.Equals(right);
        }

        [q("Zip() is Lift() (2).")]
        public static bool Zip03(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5) {
            Func<int, int, int, long> zipper = (i, j, k) => arg3 * i + arg4 * j + arg5 * k;
            var zipper1 = Fallible.Lift<int, int, int, long>(zipper);

            var p0 = Fallible<int>.η(arg0);
            var p1 = Fallible<int>.η(arg1);
            var p2 = Fallible<int>.η(arg2);

            var left = zipper1(p0, p1, p2);
            var right = FallibleExtensions.Zip(p0, p1, p2, zipper);

            return left.Equals(right);
        }

        [q("Lift() is Zip() (3).")]
        public static bool Lift04(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7) {
            Func<int, int, int, int, long> zipper = (i, j, k, l) => arg4 * i + arg5 * j + arg6 * k + arg7 * l;
            var zipper1 = Fallible.Lift<int, int, int, int, long>(zipper);

            var p0 = Fallible<int>.η(arg0);
            var p1 = Fallible<int>.η(arg1);
            var p2 = Fallible<int>.η(arg2);
            var p3 = Fallible<int>.η(arg3);

            var left = zipper1(p0, p1, p2, p3);
            var right = p0.Zip(p1, p2, p3, zipper);

            return left.Equals(right);
        }

        [q("Zip() is Lift() (3).")]
        public static bool Zip04(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7) {
            Func<int, int, int, int, long> zipper = (i, j, k, l) => arg4 * i + arg5 * j + arg6 * k + arg7 * l;
            var zipper1 = Fallible.Lift<int, int, int, int, long>(zipper);

            var p0 = Fallible<int>.η(arg0);
            var p1 = Fallible<int>.η(arg1);
            var p2 = Fallible<int>.η(arg2);
            var p3 = Fallible<int>.η(arg3);

            var left = zipper1(p0, p1, p2, p3);
            var right = FallibleExtensions.Zip(p0, p1, p2, p3, zipper);

            return left.Equals(right);
        }

        [q("Lift() is Zip() (4).")]
        public static bool Lift05(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9) {
            Func<int, int, int, int, int, long> zipper = (i, j, k, l, m) => arg5 * i + arg6 * j + arg7 * k + arg8 * l + arg9 * m;
            var zipper1 = Fallible.Lift<int, int, int, int, int, long>(zipper);

            var p0 = Fallible<int>.η(arg0);
            var p1 = Fallible<int>.η(arg1);
            var p2 = Fallible<int>.η(arg2);
            var p3 = Fallible<int>.η(arg3);
            var p4 = Fallible<int>.η(arg4);

            var left = zipper1(p0, p1, p2, p3, p4);
            var right = p0.Zip(p1, p2, p3, p4, zipper);

            return left.Equals(right);
        }

        [q("Zip() is Lift() (4).")]
        public static bool Zip05(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9) {
            Func<int, int, int, int, int, long> zipper = (i, j, k, l, m) => arg5 * i + arg6 * j + arg7 * k + arg8 * l + arg9 * m;
            var zipper1 = Fallible.Lift<int, int, int, int, int, long>(zipper);

            var p0 = Fallible<int>.η(arg0);
            var p1 = Fallible<int>.η(arg1);
            var p2 = Fallible<int>.η(arg2);
            var p3 = Fallible<int>.η(arg3);
            var p4 = Fallible<int>.η(arg4);

            var left = zipper1(p0, p1, p2, p3, p4);
            var right = FallibleExtensions.Zip(p0, p1, p2, p3, p4, zipper);

            return left.Equals(right);
        }

        [q("ReplaceBy() replaces the enclosed value if any (1).")]
        public static bool ReplaceBy01a(int arg0, int arg1) {
            var source = Fallible<int>.η(arg0);
            var result = source.ReplaceBy(arg1);

            return result.Contains(arg1);
        }

        [q("ReplaceBy() replaces the enclosed value if any (2).")]
        public static bool ReplaceBy01b(int arg0, int arg1) {
            var source = Fallible<int>.η(arg0);
            var result = FallibleExtensions.ReplaceBy(source, arg1);

            return result.Contains(arg1);
        }

        [q("ContinueWith() replaces the enclosed value if any (1).")]
        public static bool ContinueWith01a(int arg0, int arg1) {
            var source = Fallible<int>.η(arg0);
            var other = Fallible<int>.η(arg1);
            var result = source.ContinueWith(other);

            return result.Contains(arg1);
        }

        [q("ContinueWith() replaces the enclosed value if any (2).")]
        public static bool ContinueWith01b(int arg0, int arg1) {
            var source = Fallible<int>.η(arg0);
            var other = Fallible<int>.η(arg1);
            var result = FallibleExtensions.ContinueWith(source, other);

            return result.Contains(arg1);
        }

        [q("PassBy() does not change the enclosed value if any (1).")]
        public static bool PassBy01a(int arg0, int arg1) {
            var source = Fallible<int>.η(arg0);
            var other = Fallible<int>.η(arg1);
            var result = source.PassBy(other);

            return result.Contains(arg0);
        }

        [q("PassBy() does not change the enclosed value if any (2).")]
        public static bool PassBy01b(int arg0, int arg1) {
            var source = Fallible<int>.η(arg0);
            var other = Fallible<int>.η(arg1);
            var result = FallibleExtensions.PassBy(source, other);

            return result.Contains(arg0);
        }

        [q("Skip() replaces the enclosed value by Unit if any (1).")]
        public static bool Skip01a(int arg0) {
            var source = Fallible<int>.η(arg0);
            var result = source.Skip();

            return result.Contains(Unit.Default);
        }

        [q("Skip() replaces the enclosed value by Unit if any (2).")]
        public static bool Skip01b(int arg0) {
            var source = Fallible<int>.η(arg0);
            var result = FallibleExtensions.Skip(source);

            return result.Contains(Unit.Default);
        }

        [q("Using() calls Dispose() and applies binder (1).")]
        public static void Using01a() {
            var obj = new DisposableObj();
            var source = Fallible<DisposableObj>.η(obj);
            Func<DisposableObj, Fallible<int>> binder = _ => Fallible<int>.η(1);
            var result = source.Using(binder);

            Assert.True(result.Contains(1));
            Assert.True(obj.WasDisposed);
        }

        [q("Using() calls Dispose() and applies binder (2).")]
        public static void Using01b() {
            var obj = new DisposableObj();
            var source = Fallible<DisposableObj>.η(obj);
            Func<DisposableObj, Fallible<int>> binder = _ => Fallible<int>.η(1);
            var result = FallibleExtensions.Using(source, binder);

            Assert.True(result.Contains(1));
            Assert.True(obj.WasDisposed);
        }

        [q("Using() calls Dispose() and applies selector (1).")]
        public static void Using02a() {
            var obj = new DisposableObj();
            var source = Fallible<DisposableObj>.η(obj);
            Func<DisposableObj, int> selector = _ => 1;
            var result = source.Using(selector);

            Assert.True(result.Contains(1));
            Assert.True(obj.WasDisposed);
        }

        [q("Using() calls Dispose() and applies selector (2).")]
        public static void Using02b() {
            var obj = new DisposableObj();
            var source = Fallible<DisposableObj>.η(obj);
            Func<DisposableObj, int> selector = _ => 1;
            var result = FallibleExtensions.Using(source, selector);

            Assert.True(result.Contains(1));
            Assert.True(obj.WasDisposed);
        }

        [q("Ap.Apply is Select.Gather w/ the arguments flipped (1).")]
        public static bool Apply01a(int arg0, long arg1) {
            var applicative = Fallible<Func<int, long>>.η(i => arg1 * i);
            var value = Fallible<int>.η(arg0);

            var applied = applicative.Apply(value);
            var gathered = value.Gather(applicative);

            return applied.Equals(gathered);
        }

        [q("Ap.Apply is Select.Gather w/ the arguments flipped (2).")]
        public static bool Apply01b(int arg0, long arg1) {
            var applicative = Fallible<Func<int, long>>.η(i => arg1 * i);
            var value = Fallible<int>.η(arg0);

            var applied = Ap.Apply(applicative, value);
            var gathered = FallibleExtensions.Gather(value, applicative);

            return applied.Equals(gathered);
        }

        [q("Kleisli.InvokeWith is Sequence.SelectWith w/ the arguments flipped.")]
        public static bool InvokeWith01(int[] arg0, long arg1) {
            Func<int, Fallible<long>> selector = i => Fallible<long>.η(arg1 * i);

            var invoked = selector.InvokeWith(arg0);
            var selected = arg0.SelectWith(selector);

            var q = from x in invoked
                    from y in selected
                    select Enumerable.SequenceEqual(x, y);

            return q.Contains(true);
        }

        [q("Kleisli.InvokeWith is Fallible.Bind w/ the arguments flipped.")]
        public static bool InvokeWith02(int arg0, long arg1) {
            Func<int, Fallible<long>> binder = i => Fallible<long>.η(arg1 * i);
            var value = Fallible<int>.η(arg0);

            var invoked = binder.InvokeWith(value);
            var bounded = value.Bind(binder);

            return invoked.Equals(bounded);
        }
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
        public static bool Of02a(int arg0, float arg1) {
            Func<int, Fallible<int>> of = Fallible<int>.η;
            Func<int, Fallible<float>> f = x => Fallible<float>.η(arg1 * x);

            // return >=> g  ==  g
            var left = of.Compose(f).Invoke(arg0);
            var right = f(arg0);

            return left.Equals(right);
        }

        [q("Of() is a right identity for ComposeBack() (first monad rule).")]
        public static bool Of02b(int arg0, float arg1) {
            Func<int, Fallible<int>> of = Fallible<int>.η;
            Func<int, Fallible<float>> f = x => Fallible<float>.η(arg1 * x);

            // g <=< return  ==  g
            var left = f.ComposeBack(of).Invoke(arg0);
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
        public static bool Of04a(int arg0, float arg1) {
            Func<int, Fallible<float>> f = x => Fallible<float>.η(arg1 * x);

            // f >=> return  ==  f
            var left = f.Compose(Fallible<float>.η).Invoke(arg0);
            var right = f(arg0);

            return left.Equals(right);
        }

        [q("Of() is a left identity for ComposeBack() (second monad rule).")]
        public static bool Of04b(int arg0, float arg1) {
            Func<float, Fallible<float>> of = Fallible<float>.η;
            Func<int, Fallible<float>> f = x => Fallible<float>.η(arg1 * x);

            // return <=< f  ==  f
            var left = of.ComposeBack(f).Invoke(arg0);
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
        public static bool Compose01a(short arg0, int arg1, long arg2, double arg3) {
            Func<short, Fallible<int>> f = x => Fallible<int>.η(arg1 * x);
            Func<int, Fallible<long>> g = x => Fallible<long>.η(arg2 * x);
            Func<long, Fallible<double>> h = x => Fallible<double>.η(arg3 * x);

            // f >=> (g >=> h)  ==  (f >=> g) >=> h
            var left = f.Compose(g.Compose(h)).Invoke(arg0);
            var right = f.Compose(g).Compose(h).Invoke(arg0);

            return left.Equals(right);
        }

        [q("ComposeBack() is associative (third monad rule).")]
        public static bool Compose01b(short arg0, int arg1, long arg2, double arg3) {
            Func<short, Fallible<int>> f = x => Fallible<int>.η(arg1 * x);
            Func<int, Fallible<long>> g = x => Fallible<long>.η(arg2 * x);
            Func<long, Fallible<double>> h = x => Fallible<double>.η(arg3 * x);

            // f <=< (g <=< h)  ==  (f <=< g) <=< h
            var left = h.ComposeBack(g).ComposeBack(f).Invoke(arg0);
            var right = h.ComposeBack(g.ComposeBack(f)).Invoke(arg0);

            return left.Equals(right);
        }

        #endregion
    }

#endif
}

