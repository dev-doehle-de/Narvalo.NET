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

namespace Narvalo.Applicative
{
    using System;
    using System.Collections.Generic;

    using Xunit;

    public static partial class MaybeFacts
    {
        #region Repeat()

        [Fact]
        public static void Repeat_ThrowsArgumentOutOfRangeException_ForNegativeCount()
        {
            var source = Maybe.Of(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => Maybe.Repeat(source, -1));
        }

        #endregion

        #region Zip()

        [Fact]
        public static void Zip2_ThrowsArgumentNullException_ForNullZipper()
        {
            var first = Maybe.Of(1);
            var second = Maybe.Of(2);
            Func<int, int, int> zipper = null;

            Assert.Throws<ArgumentNullException>(() => first.Zip(second, zipper));
            Assert.Throws<ArgumentNullException>(() => Maybe.Zip(first, second, zipper));
        }

        [Fact]
        public static void Zip3_ThrowsArgumentNullException_ForNullZipper()
        {
            var first = Maybe.Of(1);
            var second = Maybe.Of(2);
            var third = Maybe.Of(3);
            Func<int, int, int, int> zipper = null;

            Assert.Throws<ArgumentNullException>(() => first.Zip(second, third, zipper));
            Assert.Throws<ArgumentNullException>(() => Maybe.Zip(first, second, third, zipper));
        }

        [Fact]
        public static void Zip4_ThrowsArgumentNullException_ForNullZipper()
        {
            var first = Maybe.Of(1);
            var second = Maybe.Of(2);
            var third = Maybe.Of(3);
            var fourth = Maybe.Of(4);
            Func<int, int, int, int, int> zipper = null;

            Assert.Throws<ArgumentNullException>(() => first.Zip(second, third, fourth, zipper));
            Assert.Throws<ArgumentNullException>(() => Maybe.Zip(first, second, third, fourth, zipper));
        }

        [Fact]
        public static void Zip5_ThrowsArgumentNullException_ForNullZipper()
        {
            var first = Maybe.Of(1);
            var second = Maybe.Of(2);
            var third = Maybe.Of(3);
            var fourth = Maybe.Of(4);
            var fifth = Maybe.Of(4);
            Func<int, int, int, int, int, int> zipper = null;

            Assert.Throws<ArgumentNullException>(() => first.Zip(second, third, fourth, fifth, zipper));
            Assert.Throws<ArgumentNullException>(() => Maybe.Zip(first, second, third, fourth, fifth, zipper));
        }

        #endregion

        #region Select()

        [Fact]
        public static void Select_ThrowsArgumentNullException_ForNullSelector()
        {
            var source = Maybe.Of(1);
            Func<int, int> selector = null;

            Assert.Throws<ArgumentNullException>(() => source.Select(selector));
            Assert.Throws<ArgumentNullException>(() => Maybe.Select(source, selector));
        }

        #endregion

        #region Where()

        [Fact]
        public static void Where_ThrowsArgumentNullException_ForNullPredicate()
        {
            var source = Maybe.Of(1);
            Func<int, bool> predicate = null;

            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
            Assert.Throws<ArgumentNullException>(() => Maybe.Where(source, predicate));
        }

        #endregion

        #region SelectMany()

        [Fact]
        public static void SelectMany_ThrowsArgumentNullException_ForNullValueSelector()
        {
            var source = Maybe.Of(1);
            Func<int, Maybe<int>> valueSelector = null;
            Func<int, int, int> resultSelector = (i, j) => i + j;

            Assert.Throws<ArgumentNullException>(() => source.SelectMany(valueSelector, resultSelector));
            Assert.Throws<ArgumentNullException>(() => Maybe.SelectMany(source, valueSelector, resultSelector));
        }

        [Fact]
        public static void SelectMany_ThrowsArgumentNullException_ForNullResultSelector()
        {
            var source = Maybe.Of(1);
            var middle = Maybe.Of(2);
            Func<int, Maybe<int>> valueSelector = _ => middle;
            Func<int, int, int> resultSelector = null;

            Assert.Throws<ArgumentNullException>(() => source.SelectMany(valueSelector, resultSelector));
            Assert.Throws<ArgumentNullException>(() => Maybe.SelectMany(source, valueSelector, resultSelector));
        }

        #endregion

        #region Join()

        [Fact]
        public static void Join_ThrowsArgumentNullException_ForNullResultSelector()
        {
            var source = Maybe.Of(1);
            var inner = Maybe.Of(2);
            Func<int, int> outerKeySelector = val => val;
            Func<int, int> innerKeySelector = val => val;
            Func<int, int, int> resultSelector = null;

            Assert.Throws<ArgumentNullException>(
                () => source.Join(inner, outerKeySelector, innerKeySelector, resultSelector));
            Assert.Throws<ArgumentNullException>(
                () => Maybe.Join(source, inner, outerKeySelector, innerKeySelector, resultSelector));
        }

        [Fact]
        public static void Join_ThrowsArgumentNullException_ForNullOuterKeySelector()
        {
            var source = Maybe.Of(1);
            var inner = Maybe.Of(2);
            Func<int, int> outerKeySelector = null;
            Func<int, int> innerKeySelector = val => val;
            Func<int, int, int> resultSelector = (i, j) => i + j;

            Assert.Throws<ArgumentNullException>(
                () => source.Join(inner, outerKeySelector, innerKeySelector, resultSelector));
            Assert.Throws<ArgumentNullException>(
                () => Maybe.Join(source, inner, outerKeySelector, innerKeySelector, resultSelector));
        }

        [Fact]
        public static void Join_ThrowsArgumentNullException_ForNullInnerKeySelector()
        {
            var source = Maybe.Of(1);
            var inner = Maybe.Of(2);
            Func<int, int> outerKeySelector = val => val;
            Func<int, int> innerKeySelector = null;
            Func<int, int, int> resultSelector = (i, j) => i + j;

            Assert.Throws<ArgumentNullException>(
                () => source.Join(inner, outerKeySelector, innerKeySelector, resultSelector));
            Assert.Throws<ArgumentNullException>(
                () => Maybe.Join(source, inner, outerKeySelector, innerKeySelector, resultSelector));
        }

        #endregion

        #region GroupJoin()

        [Fact]
        public static void GroupJoin_ThrowsArgumentNullException_ForNullResultSelector()
        {
            var source = Maybe.Of(1);
            var inner = Maybe.Of(2);
            Func<int, int> outerKeySelector = val => val;
            Func<int, int> innerKeySelector = val => val;
            Func<int, Maybe<int>, int> resultSelector = null;

            Assert.Throws<ArgumentNullException>(
                () => source.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector));
            Assert.Throws<ArgumentNullException>(
                () => Maybe.GroupJoin(source, inner, outerKeySelector, innerKeySelector, resultSelector));
        }

        [Fact]
        public static void GroupJoin_ThrowsArgumentNullException_ForNullOuterKeySelector()
        {
            var source = Maybe.Of(1);
            var inner = Maybe.Of(2);
            Func<int, int> outerKeySelector = null;
            Func<int, int> innerKeySelector = val => val;
            Func<int, Maybe<int>, int> resultSelector = (i, m) => 1;

            Assert.Throws<ArgumentNullException>(
                () => source.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector));
            Assert.Throws<ArgumentNullException>(
                () => Maybe.GroupJoin(source, inner, outerKeySelector, innerKeySelector, resultSelector));
        }

        [Fact]
        public static void GroupJoin_ThrowsArgumentNullException_ForNullInnerKeySelector()
        {
            var source = Maybe.Of(1);
            var inner = Maybe.Of(2);
            Func<int, int> outerKeySelector = val => val;
            Func<int, int> innerKeySelector = null;
            Func<int, Maybe<int>, int> resultSelector = (i, m) => 1;

            Assert.Throws<ArgumentNullException>(
                () => source.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector));
            Assert.Throws<ArgumentNullException>(
                () => Maybe.GroupJoin(source, inner, outerKeySelector, innerKeySelector, resultSelector));
        }

        #endregion

        #region Functor Rules

        [Fact(DisplayName = "Maybe<T> - The identity map is a fixed point for Select.")]
        public static void Satisfies_FirstFunctorLaw()
        {
            // Arrange
            var me = Maybe.Of(1);

            // Act
            var left = me.Select(Stubs<int>.Identity);
            var right = Stubs<Maybe<int>>.Identity(me);

            // Assert
            Assert.True(left.Equals(right));
        }

        [Fact(DisplayName = "Maybe<T> - Select preserves the composition operator.")]
        public static void Satisfies_FunctorSecondRule()
        {
            // Arrange
            var me = Maybe.Of(1);
            Func<int, long> g = val => (long)2 * val;
            Func<long, long> f = val => 3 * val;

            // Act
            var left = me.Select(_ => f(g(_)));
            var right = me.Select(g).Select(f);

            // Assert
            Assert.True(left.Equals(right));
        }

        #endregion

        #region Monoid Rules

        [Fact(DisplayName = "Maybe<T> - None is a left identity for OrElse.")]
        public static void Satisfies_FirstMonoidRule()
        {
            // Arrange
            var monad = Maybe.Of(1);

            // Act
            var left = Maybe<int>.None.OrElse(monad);
            var right = monad;

            // Assert
            Assert.True(left.Equals(right));
        }

        [Fact(DisplayName = "Maybe<T> - None is a right identity for OrElse.")]
        public static void Satisfies_SecondMonoidRule()
        {
            // Arrange
            var monad = Maybe.Of(1);

            // Act
            var left = monad.OrElse(Maybe<int>.None);
            var right = monad;

            // Assert
            Assert.True(left.Equals(right));
        }

        [Fact(DisplayName = "Maybe<T> - OrElse is associative.")]
        public static void Satisfies_ThirdMonoidRule()
        {
            // Arrange
            var monadA = Maybe.Of(1);
            var monadB = Maybe.Of(2);
            var monadC = Maybe.Of(3);

            // Act
            var left = monadA.OrElse(monadB.OrElse(monadC));
            var right = monadA.OrElse(monadB).OrElse(monadC);

            // Assert
            Assert.True(left.Equals(right));
        }

        #endregion

        #region Monad Rules

        [Fact(DisplayName = "Maybe<T> - Of is a left identity for Bind.")]
        public static void Satisfies_FirstMonadRule()
        {
            // Arrange
            int value = 1;
            Func<int, Maybe<long>> binder = val => Maybe.Of((long)2 * val);

            // Act
            var left = Maybe.Of(value).Bind(binder);
            var right = binder(value);

            // Assert
            Assert.True(left.Equals(right));
        }

        [Fact(DisplayName = "Maybe<T> - Of is a right identity for Bind.")]
        public static void Satisfies_SecondMonadRule()
        {
            // Arrange
            Func<int, Maybe<int>> create = val => Maybe.Of(val);
            var monad = Maybe.Of(1);

            // Act
            var left = monad.Bind(create);
            var right = monad;

            // Assert
            Assert.True(left.Equals(right));
        }

        [Fact(DisplayName = "Maybe<T> - Bind is associative.")]
        public static void Satisfies_ThirdMonadRule()
        {
            // Arrange
            Maybe<short> m = Maybe.Of((short)1);
            Func<short, Maybe<int>> f = val => Maybe.Of((int)3 * val);
            Func<int, Maybe<long>> g = val => Maybe.Of((long)2 * val);

            // Act
            var left = m.Bind(f).Bind(g);
            var right = m.Bind(val => f(val).Bind(g));

            // Assert
            Assert.True(left.Equals(right));
        }

        [Fact]
        public static void Satisfies_MonadZeroRule()
        {
            // Arrange
            Func<int, Maybe<long>> kun = val => Maybe.Of((long)2 * val);

            // Act
            var left = Maybe<int>.None.Bind(kun);
            var right = Maybe<long>.None;

            // Assert
            Assert.True(left.Equals(right));
        }

        [Fact]
        public static void Satisfies_MonadMoreRule()
        {
            // Act
            var leftSome = Maybe.Of(1).Bind(val => Maybe<int>.None);
            var leftNone = Maybe<int>.None.Bind(val => Maybe<int>.None);
            var right = Maybe<int>.None;

            // Assert
            Assert.True(leftSome.Equals(right));
            Assert.True(leftNone.Equals(right));
        }

        [Fact]
        public static void Satisfies_MonadOrRule()
        {
            // Arrange
            var monad = Maybe.Of(2);

            // Act
            var leftSome = monad.OrElse(Maybe.Of(1));
            var leftNone = monad.OrElse(Maybe<int>.None);
            var right = monad;

            // Assert
            Assert.True(leftSome.Equals(right));
            Assert.True(leftNone.Equals(right));
        }

        [Fact]
        public static void DoesNotSatisfyRightZeroForPlus()
        {
            // Arrange
            var monad = Maybe.Of(2);

            // Act
            var leftSome = Maybe.Of(1).OrElse(monad);
            var leftNone = Maybe<int>.None.OrElse(monad);
            var right = monad;

            // Assert
            Assert.False(leftSome.Equals(right));   // NB: Fails here the "Unit is a right zero for Plus".
            Assert.True(leftNone.Equals(right));
        }

        #endregion
    }
}

