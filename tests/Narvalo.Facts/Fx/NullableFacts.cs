﻿namespace Narvalo.Fx
{
    using System;
    using Xunit;

    public static class NullableFacts
    {
        public static class TheWhereOperator
        {
            [Fact]
            public static void ReturnsValue_ForSuccessfulPredicate()
            {
                // Arrange
                int? source = 1;
                Func<int, bool> predicate = _ => _ == 1;

                // Act
                var m = source.Where(predicate);
                var q = from _ in source where predicate(_) select _;

                // Assert
                Assert.True(m.HasValue);
                Assert.True(q.HasValue);
                Assert.Equal(1, m.Value);
                Assert.Equal(1, q.Value);
            }

            [Fact]
            public static void ReturnsNull_ForFailedPredicate()
            {
                // Arrange
                int? source = 1;
                Func<int, bool> predicate = _ => _ == 2;

                // Act
                var m = source.Where(predicate);
                var q = from _ in source where predicate(_) select _;

                // Assert
                Assert.False(m.HasValue);
                Assert.False(q.HasValue);
            }
        }

        public static class TheSelectOperator
        {
            [Fact]
            public static void ReturnsNull_WhenSourceIsNull()
            {
                // Arrange
                int? source = null;
                Func<int, int> selector = _ => _;

                // Act
                var m = source.Select(selector);
                var q = from _ in source select selector(_);

                // Assert
                Assert.False(m.HasValue);
                Assert.False(q.HasValue);
            }

            [Fact]
            public static void ReturnsValueAndApplySelector_WhenSourceHasValue()
            {
                // Arrange
                int? source = 1;
                Func<int, int> selector = _ => 2 * _;

                // Act
                var m = source.Select(selector);
                var q = from _ in source select selector(_);

                // Assert
                Assert.True(m.HasValue);
                Assert.True(q.HasValue);
                Assert.Equal(2, m.Value);
                Assert.Equal(2, q.Value);
            }
        }

        public static class TheSelectManyOperator
        {
            [Fact]
            public static void ReturnsNull_WhenSourceIsNull()
            {
                // Arrange
                int? source = null;
                int? middle = 2;
                Func<int, int?> valueSelector = _ => middle;
                Func<int, int, int> resultSelector = (i, j) => i + j;

                // Act
                var m = source.SelectMany(valueSelector, resultSelector);
                var q = from i in source
                        from j in middle
                        select resultSelector(i, j);

                // Assert
                Assert.False(m.HasValue);
                Assert.False(q.HasValue);
            }

            [Fact]
            public static void ReturnsNull_ForMiddleIsNull()
            {
                // Arrange
                int? source = 1;
                int? middle = null;
                Func<int, int?> valueSelector = _ => middle;
                Func<int, int, int> resultSelector = (i, j) => i + j;

                // Act
                var m = source.SelectMany(valueSelector, resultSelector);
                var q = from i in source
                        from j in middle
                        select resultSelector(i, j);

                // Assert
                Assert.False(m.HasValue);
                Assert.False(q.HasValue);
            }

            [Fact]
            public static void ReturnsNone_WhenSourceIsNone_ForMiddleIsNone()
            {
                // Arrange
                int? source = null;
                int? middle = null;
                Func<int, int?> valueSelector = _ => middle;
                Func<int, int, int> resultSelector = (i, j) => i + j;

                // Act
                var m = source.SelectMany(valueSelector, resultSelector);
                var q = from i in source
                        from j in middle
                        select resultSelector(i, j);

                // Assert
                Assert.False(m.HasValue);
                Assert.False(q.HasValue);
            }

            [Fact]
            public static void ReturnsValueAndApplySelector()
            {
                // Arrange
                int? source = 1;
                int? middle = 2;
                Func<int, int?> valueSelector = _ => middle;
                Func<int, int, int> resultSelector = (i, j) => i + j;

                // Act
                var m = source.SelectMany(valueSelector, resultSelector);
                var q = from i in source
                        from j in middle
                        select resultSelector(i, j);

                // Assert
                Assert.True(m.HasValue);
                Assert.True(q.HasValue);
                Assert.Equal(3, m.Value);
                Assert.Equal(3, q.Value);
            }
        }
    }
}