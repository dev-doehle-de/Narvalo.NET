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

    // Provides tests for Maybe<T>.
    // T4: EmitMonadCore().
    public static partial class MaybeFacts {
        internal sealed class tAttribute : FactAttribute {
            public tAttribute(string description) : base() {
                DisplayName = nameof(Maybe) + " - " + description;
            }
        }

        internal sealed class TAttribute : TheoryAttribute {
            public TAttribute(string description) : base() {
                DisplayName = nameof(Maybe) + " - " + description;
            }
        }

        internal sealed class qAttribute : PropertyAttribute {
            public qAttribute(string description) : base() {
                DisplayName = nameof(Maybe) + " - " + description;
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
    public static partial class MaybeFacts {
        [t("Compose() guards.")]
        public static void Compose0() {
            Func<int, Maybe<int>> first = null;
            Func<int, Maybe<int>> second = i => Maybe<int>.η(1);

            Assert.Throws<ArgumentNullException>("this", () => first.Compose(second));
        }

        [t("Compose() guards.")]
        public static void ComposeBack0() {
            Func<int, Maybe<int>> first = i => Maybe<int>.η(1);
            Func<int, Maybe<int>> second = null;

            Assert.Throws<ArgumentNullException>("second", () => first.ComposeBack(second));
        }

        [t("Repeat() guards.")]
        public static void Repeat0() {
            var source = Maybe<int>.η(1);

            Assert.Throws<ArgumentOutOfRangeException>("count", () => Maybe.Repeat(source, -1));
        }

        [t("Zip() guards.")]
        public static void Zip0() {
            var first = Maybe<int>.η(1);
            var second = Maybe<int>.η(2);
            var third = Maybe<int>.η(3);
            var fourth = Maybe<int>.η(4);
            var fifth = Maybe<int>.η(5);
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
            Assert.Throws<ArgumentNullException>("zipper", () => Maybe.Zip(first, second, zipper2));
            Assert.Throws<ArgumentNullException>("zipper", () => Maybe.Zip(first, second, third, zipper3));
            Assert.Throws<ArgumentNullException>("zipper", () => Maybe.Zip(first, second, third, fourth, zipper4));
            Assert.Throws<ArgumentNullException>("zipper", () => Maybe.Zip(first, second, third, fourth, fifth, zipper5));
        }

        [t("Select() guards.")]
        public static void Select0() {
            var source = Maybe<int>.η(1);
            Func<int, long> selector = null;

            Assert.Throws<ArgumentNullException>("selector", () => source.Select(selector));
            Assert.Throws<ArgumentNullException>("selector", () => Maybe.Select(source, selector));
        }

        [t("Using() guards.")]
        public static void Using0() {
            var source = Maybe<DisposableObj>.η(new DisposableObj());
            Func<DisposableObj, Maybe<int>> binder = null;
            Func<DisposableObj, int> selector = null;

            Assert.Throws<ArgumentNullException>("binder", () => source.Using(binder));
            Assert.Throws<ArgumentNullException>("binder", () => Maybe.Using(source, binder));

            Assert.Throws<ArgumentNullException>("selector", () => source.Using(selector));
            Assert.Throws<ArgumentNullException>("selector", () => Maybe.Using(source, selector));
        }

        [t("Where() guards.")]
        public static void Where0() {
            var source = Maybe<int>.η(1);

            Assert.Throws<ArgumentNullException>("predicate", () => source.Where(null));
            Assert.Throws<ArgumentNullException>("predicate", () => Maybe.Where(source, null));
        }

        [t("SelectMany() guards.")]
        public static void SelectMany0() {
            var source = Maybe<short>.η(1);
            var middle = Maybe<int>.η(2);
            Func<short, Maybe<int>> valueSelector = i => Maybe<int>.η(i);
            Func<short, int, long> resultSelector = (i, j) => i + j;

            // Extension method.
            Assert.Throws<ArgumentNullException>("selector", () => source.SelectMany(null, resultSelector));
            Assert.Throws<ArgumentNullException>("resultSelector", () => source.SelectMany(valueSelector, (Func<short, int, long>)null));
            // Static method.
            Assert.Throws<ArgumentNullException>("selector", () => Maybe.SelectMany(source, null, resultSelector));
            Assert.Throws<ArgumentNullException>("resultSelector", () => Maybe.SelectMany(source, valueSelector, (Func<short, int, long>)null));
        }

        [t("Join() guards.")]
        public static void Join0() {
            var source = Maybe<int>.η(1);
            var inner = Maybe<int>.η(2);
            Func<int, int> outerKeySelector = val => val;
            Func<int, int> innerKeySelector = val => val;
            Func<int, int, int> resultSelector = (i, j) => i + j;

            // Extension method.
            Assert.Throws<ArgumentNullException>("outerKeySelector",
                () => source.Join(inner, (Func<int, int>)null, innerKeySelector, resultSelector));
            Assert.Throws<ArgumentNullException>("innerKeySelector",
                () => source.Join(inner, outerKeySelector, (Func<int, int>)null, resultSelector));
            Assert.Throws<ArgumentNullException>("resultSelector",
                () => source.Join(inner, outerKeySelector, innerKeySelector, (Func<int, int, int>)null));
            Assert.Throws<ArgumentNullException>("comparer",
                () => source.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null));
            // Static method.
            Assert.Throws<ArgumentNullException>("outerKeySelector",
                () => Maybe.Join(source, inner, (Func<int, int>)null, innerKeySelector, resultSelector));
            Assert.Throws<ArgumentNullException>("innerKeySelector",
                () => Maybe.Join(source, inner, outerKeySelector, (Func<int, int>)null, resultSelector));
            Assert.Throws<ArgumentNullException>("resultSelector",
                () => Maybe.Join(source, inner, outerKeySelector, innerKeySelector, (Func<int, int, int>)null));
            Assert.Throws<ArgumentNullException>("comparer",
                () => Maybe.Join(source, inner, outerKeySelector, innerKeySelector, resultSelector, null));
        }

        [t("GroupJoin() guards.")]
        public static void GroupJoin0() {
            var source = Maybe<int>.η(1);
            var inner = Maybe<int>.η(2);
            Func<int, int> outerKeySelector = val => val;
            Func<int, int> innerKeySelector = val => val;
            Func<int, Maybe<int>, int> resultSelector = (i, m) => 1;

            // Extension method.
            Assert.Throws<ArgumentNullException>("outerKeySelector",
                () => source.GroupJoin(inner, (Func<int, int>)null, innerKeySelector, resultSelector));
            Assert.Throws<ArgumentNullException>("innerKeySelector",
                () => source.GroupJoin(inner, outerKeySelector, (Func<int, int>)null, resultSelector));
            Assert.Throws<ArgumentNullException>("resultSelector",
                () => source.GroupJoin(inner, outerKeySelector, innerKeySelector, (Func<int, Maybe<int>, int>)null));
            Assert.Throws<ArgumentNullException>("comparer",
                () => source.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, null));
            // Static method.
            Assert.Throws<ArgumentNullException>("outerKeySelector",
                () => Maybe.GroupJoin(source, inner, (Func<int, int>)null, innerKeySelector, resultSelector));
            Assert.Throws<ArgumentNullException>("innerKeySelector",
                () => Maybe.GroupJoin(source, inner, outerKeySelector, (Func<int, int>)null, resultSelector));
            Assert.Throws<ArgumentNullException>("resultSelector",
                () => Maybe.GroupJoin(source, inner, outerKeySelector, innerKeySelector, (Func<int, Maybe<int>, int>)null));
            Assert.Throws<ArgumentNullException>("comparer",
                () => Maybe.GroupJoin(source, inner, outerKeySelector, innerKeySelector, resultSelector, null));
        }
    }

#endif

#if !NO_INTERNALS_VISIBLE_TO

    // T4: EmitMonadTests().
    public static partial class MaybeFacts {
        [t("Guard(true) returns Maybe.Unit.")]
        public static void Guard01() {
            var result = Maybe.Guard(true);

            Assert.Equal(Maybe.Unit, result);
        }

        [t("Guard(false) returns Maybe.None.")]
        public static void Guard02() {
            var result = Maybe.Guard(false);

            Assert.Equal(Maybe.None, result);
        }

        [q("Repeat() repeats the enclosed value if any.")]
        public static bool Repeat01(int arg) {
            var source = Maybe<int>.η(arg);

            var result = Maybe.Repeat(source, 10);
            var seq = Enumerable.Repeat(arg, 10);

            var q = from x in result select Enumerable.SequenceEqual(x, seq);

            return q.Contains(true);
        }

        [q("Lift() is Select().")]
        public static bool Lift01(int arg0, long arg1) {
            Func<int, long> selector = i => arg1 * i;
            var selector1 = Maybe.Lift<int, long>(selector);

            var source = Maybe<int>.η(arg0);

            var left = selector1(source);
            var right = source.Select(selector);

            return left.Equals(right);
        }

        [q("Select() is Lift().")]
        public static bool Select01(int arg0, long arg1) {
            Func<int, long> selector = i => arg1 * i;
            var selector1 = Maybe.Lift<int, long>(selector);

            var source = Maybe<int>.η(arg0);

            var left = selector1(source);
            var right = Maybe.Select(source, selector);

            return left.Equals(right);
        }

        [q("Lift() is Zip() (1).")]
        public static bool Lift02(int arg0, int arg1, int arg2, int arg3) {
            Func<int, int, long> zipper = (i, j) => arg2 * i + arg3 * j;
            var zipper1 = Maybe.Lift<int, int, long>(zipper);

            var p0 = Maybe<int>.η(arg0);
            var p1 = Maybe<int>.η(arg1);

            var left = zipper1(p0, p1);
            var right = p0.Zip(p1, zipper);

            return left.Equals(right);
        }

        // NB: Lift01() but w/o using Zip as an extension method.
        [q("Zip() is Lift() (1).")]
        public static bool Zip02(int arg0, int arg1, int arg2, int arg3) {
            Func<int, int, long> zipper = (i, j) => arg2 * i + arg3 * j;
            var zipper1 = Maybe.Lift<int, int, long>(zipper);

            var p0 = Maybe<int>.η(arg0);
            var p1 = Maybe<int>.η(arg1);

            var left = zipper1(p0, p1);
            var right = Maybe.Zip(p0, p1, zipper);

            return left.Equals(right);
        }

        [q("Lift() is Zip() (2).")]
        public static bool Lift03(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5) {
            Func<int, int, int, long> zipper = (i, j, k) => arg3 * i + arg4 * j + arg5 * k;
            var zipper1 = Maybe.Lift<int, int, int, long>(zipper);

            var p0 = Maybe<int>.η(arg0);
            var p1 = Maybe<int>.η(arg1);
            var p2 = Maybe<int>.η(arg2);

            var left = zipper1(p0, p1, p2);
            var right = p0.Zip(p1, p2, zipper);

            return left.Equals(right);
        }

        [q("Zip() is Lift() (2).")]
        public static bool Zip03(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5) {
            Func<int, int, int, long> zipper = (i, j, k) => arg3 * i + arg4 * j + arg5 * k;
            var zipper1 = Maybe.Lift<int, int, int, long>(zipper);

            var p0 = Maybe<int>.η(arg0);
            var p1 = Maybe<int>.η(arg1);
            var p2 = Maybe<int>.η(arg2);

            var left = zipper1(p0, p1, p2);
            var right = Maybe.Zip(p0, p1, p2, zipper);

            return left.Equals(right);
        }

        [q("Lift() is Zip() (3).")]
        public static bool Lift04(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7) {
            Func<int, int, int, int, long> zipper = (i, j, k, l) => arg4 * i + arg5 * j + arg6 * k + arg7 * l;
            var zipper1 = Maybe.Lift<int, int, int, int, long>(zipper);

            var p0 = Maybe<int>.η(arg0);
            var p1 = Maybe<int>.η(arg1);
            var p2 = Maybe<int>.η(arg2);
            var p3 = Maybe<int>.η(arg3);

            var left = zipper1(p0, p1, p2, p3);
            var right = p0.Zip(p1, p2, p3, zipper);

            return left.Equals(right);
        }

        [q("Zip() is Lift() (3).")]
        public static bool Zip04(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7) {
            Func<int, int, int, int, long> zipper = (i, j, k, l) => arg4 * i + arg5 * j + arg6 * k + arg7 * l;
            var zipper1 = Maybe.Lift<int, int, int, int, long>(zipper);

            var p0 = Maybe<int>.η(arg0);
            var p1 = Maybe<int>.η(arg1);
            var p2 = Maybe<int>.η(arg2);
            var p3 = Maybe<int>.η(arg3);

            var left = zipper1(p0, p1, p2, p3);
            var right = Maybe.Zip(p0, p1, p2, p3, zipper);

            return left.Equals(right);
        }

        [q("Lift() is Zip() (4).")]
        public static bool Lift05(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9) {
            Func<int, int, int, int, int, long> zipper = (i, j, k, l, m) => arg5 * i + arg6 * j + arg7 * k + arg8 * l + arg9 * m;
            var zipper1 = Maybe.Lift<int, int, int, int, int, long>(zipper);

            var p0 = Maybe<int>.η(arg0);
            var p1 = Maybe<int>.η(arg1);
            var p2 = Maybe<int>.η(arg2);
            var p3 = Maybe<int>.η(arg3);
            var p4 = Maybe<int>.η(arg4);

            var left = zipper1(p0, p1, p2, p3, p4);
            var right = p0.Zip(p1, p2, p3, p4, zipper);

            return left.Equals(right);
        }

        [q("Zip() is Lift() (4).")]
        public static bool Zip05(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9) {
            Func<int, int, int, int, int, long> zipper = (i, j, k, l, m) => arg5 * i + arg6 * j + arg7 * k + arg8 * l + arg9 * m;
            var zipper1 = Maybe.Lift<int, int, int, int, int, long>(zipper);

            var p0 = Maybe<int>.η(arg0);
            var p1 = Maybe<int>.η(arg1);
            var p2 = Maybe<int>.η(arg2);
            var p3 = Maybe<int>.η(arg3);
            var p4 = Maybe<int>.η(arg4);

            var left = zipper1(p0, p1, p2, p3, p4);
            var right = Maybe.Zip(p0, p1, p2, p3, p4, zipper);

            return left.Equals(right);
        }

        [q("ReplaceBy() replaces the enclosed value if any (1).")]
        public static bool ReplaceBy01a(int arg0, int arg1) {
            var source = Maybe<int>.η(arg0);
            var result = source.ReplaceBy(arg1);

            return result.Contains(arg1);
        }

        [q("ReplaceBy() replaces the enclosed value if any (2).")]
        public static bool ReplaceBy01b(int arg0, int arg1) {
            var source = Maybe<int>.η(arg0);
            var result = Maybe.ReplaceBy(source, arg1);

            return result.Contains(arg1);
        }

        [q("ContinueWith() replaces the enclosed value if any (1).")]
        public static bool ContinueWith01a(int arg0, int arg1) {
            var source = Maybe<int>.η(arg0);
            var other = Maybe<int>.η(arg1);
            var result = source.ContinueWith(other);

            return result.Contains(arg1);
        }

        [q("ContinueWith() replaces the enclosed value if any (2).")]
        public static bool ContinueWith01b(int arg0, int arg1) {
            var source = Maybe<int>.η(arg0);
            var other = Maybe<int>.η(arg1);
            var result = Maybe.ContinueWith(source, other);

            return result.Contains(arg1);
        }

        [q("PassBy() does not change the enclosed value if any (1).")]
        public static bool PassBy01a(int arg0, int arg1) {
            var source = Maybe<int>.η(arg0);
            var other = Maybe<int>.η(arg1);
            var result = source.PassBy(other);

            return result.Contains(arg0);
        }

        [q("PassBy() does not change the enclosed value if any (2).")]
        public static bool PassBy01b(int arg0, int arg1) {
            var source = Maybe<int>.η(arg0);
            var other = Maybe<int>.η(arg1);
            var result = Maybe.PassBy(source, other);

            return result.Contains(arg0);
        }

        [q("Skip() replaces the enclosed value by Unit if any (1).")]
        public static bool Skip01a(int arg0) {
            var source = Maybe<int>.η(arg0);
            var result = source.Skip();

            return result.Contains(Unit.Default);
        }

        [q("Skip() replaces the enclosed value by Unit if any (2).")]
        public static bool Skip01b(int arg0) {
            var source = Maybe<int>.η(arg0);
            var result = Maybe.Skip(source);

            return result.Contains(Unit.Default);
        }

        [q("Using() calls Dispose() and applies binder (1).")]
        public static void Using01a() {
            var obj = new DisposableObj();
            var source = Maybe<DisposableObj>.η(obj);
            Func<DisposableObj, Maybe<int>> binder = _ => Maybe<int>.η(1);
            var result = source.Using(binder);

            Assert.True(result.Contains(1));
            Assert.True(obj.WasDisposed);
        }

        [q("Using() calls Dispose() and applies binder (2).")]
        public static void Using01b() {
            var obj = new DisposableObj();
            var source = Maybe<DisposableObj>.η(obj);
            Func<DisposableObj, Maybe<int>> binder = _ => Maybe<int>.η(1);
            var result = Maybe.Using(source, binder);

            Assert.True(result.Contains(1));
            Assert.True(obj.WasDisposed);
        }

        [q("Using() calls Dispose() and applies selector (1).")]
        public static void Using02a() {
            var obj = new DisposableObj();
            var source = Maybe<DisposableObj>.η(obj);
            Func<DisposableObj, int> selector = _ => 1;
            var result = source.Using(selector);

            Assert.True(result.Contains(1));
            Assert.True(obj.WasDisposed);
        }

        [q("Using() calls Dispose() and applies selector (2).")]
        public static void Using02b() {
            var obj = new DisposableObj();
            var source = Maybe<DisposableObj>.η(obj);
            Func<DisposableObj, int> selector = _ => 1;
            var result = Maybe.Using(source, selector);

            Assert.True(result.Contains(1));
            Assert.True(obj.WasDisposed);
        }

        [q("Ap.Apply is Select.Gather w/ the arguments flipped (1).")]
        public static bool Apply01a(int arg0, long arg1) {
            var applicative = Maybe<Func<int, long>>.η(i => arg1 * i);
            var value = Maybe<int>.η(arg0);

            var applied = applicative.Apply(value);
            var gathered = value.Gather(applicative);

            return applied.Equals(gathered);
        }

        [q("Ap.Apply is Select.Gather w/ the arguments flipped (2).")]
        public static bool Apply01b(int arg0, long arg1) {
            var applicative = Maybe<Func<int, long>>.η(i => arg1 * i);
            var value = Maybe<int>.η(arg0);

            var applied = Ap.Apply(applicative, value);
            var gathered = Maybe.Gather(value, applicative);

            return applied.Equals(gathered);
        }

        [q("Kleisli.InvokeWith is Sequence.SelectWith w/ the arguments flipped.")]
        public static bool InvokeWith01(int[] arg0, long arg1) {
            Func<int, Maybe<long>> selector = i => Maybe<long>.η(arg1 * i);

            var invoked = selector.InvokeWith(arg0);
            var selected = arg0.SelectWith(selector);

            var q = from x in invoked
                    from y in selected
                    select Enumerable.SequenceEqual(x, y);

            return q.Contains(true);
        }

        [q("Kleisli.InvokeWith is Maybe.Bind w/ the arguments flipped.")]
        public static bool InvokeWith02(int arg0, long arg1) {
            Func<int, Maybe<long>> binder = i => Maybe<long>.η(arg1 * i);
            var value = Maybe<int>.η(arg0);

            var invoked = binder.InvokeWith(value);
            var bounded = value.Bind(binder);

            return invoked.Equals(bounded);
        }
    }

#endif

#if !NO_INTERNALS_VISIBLE_TO

    // Provides tests for Maybe<T>: functor, monoid and monad laws.
    // T4: EmitMonadRules().
    public static partial class MaybeFacts {
        #region Functor Rules

        [q("The identity map is a fixed point for Select() (first functor rule).")]
        public static bool Select01(int arg) {
            var m = Maybe<int>.η(arg);

            // fmap id  ==  id
            var left = m.Select(x => x);
            var right = m;

            return left.Equals(right);
        }

        [q("Select() preserves the composition operator (second functor rule).")]
        public static bool Select02(short arg0, int arg1, long arg2) {
            var m = Maybe<short>.η(arg0);
            Func<short, int> g = x => arg1 * x;
            Func<int, long> f = x => arg2 * x;

            // fmap (f . g)  ==  fmap f . fmap g
            var left = m.Select(val => f(g(val)));
            var right = m.Select(g).Select(f);

            return left.Equals(right);
        }

        #endregion

        #region Monoïd Rules

        [q("None is a left identity for OrElse().")]
        public static bool None01(int arg) {
            var m = Maybe<int>.η(arg);

            // mappend mempty x  ==  x
            var left = Maybe<int>.None.OrElse(m);
            var right = m;

            return left.Equals(right);
        }

        [q("None is a right identity for OrElse().")]
        public static bool None02(int arg) {
            var m = Maybe<int>.η(arg);

            // mappend x mempty ==  x
            var left = m.OrElse(Maybe<int>.None);
            var right = m;

            return left.Equals(right);
        }

        [q("OrElse() is associative.")]
        public static bool OrElse01(int arg0, int arg1, int arg2) {
            var x = Maybe<int>.η(arg0);
            var y = Maybe<int>.η(arg1);
            var z = Maybe<int>.η(arg2);

            // mappend x (mappend y z)  ==  mappend (mappend x y) z
            var left = x.OrElse(y.OrElse(z));
            var right = x.OrElse(y).OrElse(z);

            return left.Equals(right);
        }

        #endregion

        #region Monad Rules

        [q("Of() is a left identity for Bind() (first monad rule).")]
        public static bool Of01(int arg0, float arg1) {
            Func<int, Maybe<float>> f = x => Maybe<float>.η(arg1 * x);

            // return a >>= k  ==  k a
            var left = Maybe<int>.η(arg0).Bind(f);
            var right = f(arg0);

            return left.Equals(right);
        }

        [q("Of() is a left identity for Compose() (first monad rule).")]
        public static bool Of02a(int arg0, float arg1) {
            Func<int, Maybe<int>> of = Maybe<int>.η;
            Func<int, Maybe<float>> f = x => Maybe<float>.η(arg1 * x);

            // return >=> g  ==  g
            var left = of.Compose(f).Invoke(arg0);
            var right = f(arg0);

            return left.Equals(right);
        }

        [q("Of() is a right identity for ComposeBack() (first monad rule).")]
        public static bool Of02b(int arg0, float arg1) {
            Func<int, Maybe<int>> of = Maybe<int>.η;
            Func<int, Maybe<float>> f = x => Maybe<float>.η(arg1 * x);

            // g <=< return  ==  g
            var left = f.ComposeBack(of).Invoke(arg0);
            var right = f(arg0);

            return left.Equals(right);
        }

        [q("Of() is a right identity for Bind() (second monad rule).")]
        public static bool Of03(int arg0) {
            var m = Maybe<int>.η(arg0);

            // m >>= return  ==  m
            var left = m.Bind(Maybe<int>.η);
            var right = m;

            return left.Equals(right);
        }

        [q("Of() is a right identity for Compose() (second monad rule).")]
        public static bool Of04a(int arg0, float arg1) {
            Func<int, Maybe<float>> f = x => Maybe<float>.η(arg1 * x);

            // f >=> return  ==  f
            var left = f.Compose(Maybe<float>.η).Invoke(arg0);
            var right = f(arg0);

            return left.Equals(right);
        }

        [q("Of() is a left identity for ComposeBack() (second monad rule).")]
        public static bool Of04b(int arg0, float arg1) {
            Func<float, Maybe<float>> of = Maybe<float>.η;
            Func<int, Maybe<float>> f = x => Maybe<float>.η(arg1 * x);

            // return <=< f  ==  f
            var left = of.ComposeBack(f).Invoke(arg0);
            var right = f(arg0);

            return left.Equals(right);
        }

        [q("Bind() is associative (third monad rule).")]
        public static bool Bind01(short arg0, int arg1, long arg2) {
            var m = Maybe<short>.η(arg0);

            Func<short, Maybe<int>> f = x => Maybe<int>.η(arg1 * x);
            Func<int, Maybe<long>> g = x => Maybe<long>.η(arg2 * x);

            // m >>= (\x -> f x >>= g)  ==  (m >>= f) >>= g
            var left = m.Bind(f).Bind(g);
            var right = m.Bind(val => f(val).Bind(g));

            return left.Equals(right);
        }

        [q("Compose() is associative (third monad rule).")]
        public static bool Compose01a(short arg0, int arg1, long arg2, double arg3) {
            Func<short, Maybe<int>> f = x => Maybe<int>.η(arg1 * x);
            Func<int, Maybe<long>> g = x => Maybe<long>.η(arg2 * x);
            Func<long, Maybe<double>> h = x => Maybe<double>.η(arg3 * x);

            // f >=> (g >=> h)  ==  (f >=> g) >=> h
            var left = f.Compose(g.Compose(h)).Invoke(arg0);
            var right = f.Compose(g).Compose(h).Invoke(arg0);

            return left.Equals(right);
        }

        [q("ComposeBack() is associative (third monad rule).")]
        public static bool Compose01b(short arg0, int arg1, long arg2, double arg3) {
            Func<short, Maybe<int>> f = x => Maybe<int>.η(arg1 * x);
            Func<int, Maybe<long>> g = x => Maybe<long>.η(arg2 * x);
            Func<long, Maybe<double>> h = x => Maybe<double>.η(arg3 * x);

            // f <=< (g <=< h)  ==  (f <=< g) <=< h
            var left = h.ComposeBack(g).ComposeBack(f).Invoke(arg0);
            var right = h.ComposeBack(g.ComposeBack(f)).Invoke(arg0);

            return left.Equals(right);
        }

        #endregion

        #region Monad Zero, Plus and More Rules

        [q("None is is a left zero for Bind() (monad-zero rule).")]
        public static bool None03(long arg0) {
            Func<int, Maybe<long>> f = x => Maybe<long>.η(arg0 * x);

            // mzero >>= f  ==  mzero
            var left = Maybe<int>.None.Bind(f);
            var right = Maybe<long>.None;

            return left.Equals(right);
        }

        [q("None is is a right zero for Bind() (monad-more rule).")]
        public static bool None04(int arg0) {
            // m >>= (\x -> mzero) = mzero
            var left = Maybe<int>.η(arg0).Bind(_ => Maybe<long>.None);
            var right = Maybe<long>.None;

            return left.Equals(right);
        }

        [q("Of() is a left zero for OrElse() (monad-or rule (1)).")]
        public static bool Of05(int arg0, int arg1) {
            var m = Maybe<int>.η(arg0);
            var right = m;

            // morelse (return a) b  ==  return a
            var left = m.OrElse(Maybe<int>.η(arg1));

            return left.Equals(right);
        }

        [q("Of() is a left zero for OrElse() (monad-or rule (2)).")]
        public static bool Of06(int arg0) {
            var m = Maybe<int>.η(arg0);
            var right = m;

            // morelse (return a) b  ==  return a
            var left = m.OrElse(Maybe<int>.None);

            return left.Equals(right);
        }

        [q("Of() is a right zero for OrElse() (monad-plus rule (1)).")]
        public static bool Of07(int arg0) {
            var m = Maybe<int>.η(arg0);
            var right = m;

            // morelse b (return a)  ==  return a
            var left = Maybe<int>.None.OrElse(m);

            return left.Equals(right);
        }

        [q("Of() is NOT a right zero for OrElse() (monad-plus rule (2)).")]
        public static bool Of08(int arg0, int arg1) {
            // FIXME: filter before?
            if (arg0 == arg1) { return true; }

            var m = Maybe<int>.η(arg0);
            var right = m;

            // morelse b (return a)  !=  return a
            var left = Maybe<int>.η(arg1).OrElse(m);

            // NB: Fails here the "Unit is a right zero for Plus".
            return !left.Equals(right);
        }

        #endregion
    }

#endif
}

