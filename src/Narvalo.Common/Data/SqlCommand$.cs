﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Data
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Provides extension methods for <see cref="SqlCommand"/>.
    /// </summary>
    public static class SqlCommandExtensions
    {
        public static void AddParameter(
            this SqlCommand @this,
            string parameterName,
            SqlDbType parameterType,
            object value)
        {
            Require.NotNull(@this, nameof(@this));

            @this.Parameters.AddParameterUnchecked(parameterName, parameterType, value);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", MessageId = "0",
            Justification = "[Intentionally] This method clearly states that the responsibility for null-checks is on the callers.")]
        public static void AddParameterUnchecked(
            this SqlCommand @this,
            string parameterName,
            SqlDbType parameterType,
            object value)
        {
            @this.Parameters.AddParameterUnchecked(parameterName, parameterType, value);
        }

        public static void AddParameterOrNull<T>(
            this SqlCommand @this,
            string parameterName,
            SqlDbType parameterType,
            T? value)
            where T : struct
        {
            Require.NotNull(@this, nameof(@this));

            @this.Parameters.AddParameterOrNullUnchecked(parameterName, parameterType, value);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", MessageId = "0",
            Justification = "[Intentionally] This method clearly states that the responsibility for null-checks is on the callers.")]
        public static void AddParameterOrNullUnchecked<T>(
            this SqlCommand @this,
            string parameterName,
            SqlDbType parameterType,
            T? value)
            where T : struct
        {
            @this.Parameters.AddParameterOrNullUnchecked(parameterName, parameterType, value);
        }

        public static void AddParameterOrNull<T>(
            this SqlCommand @this,
            string parameterName,
            SqlDbType parameterType,
            T value)
        {
            Require.NotNull(@this, nameof(@this));

            @this.Parameters.AddParameterOrNullUnchecked(parameterName, parameterType, value, value != null);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", MessageId = "0",
            Justification = "[Intentionally] This method clearly states that the responsibility for null-checks is on the callers.")]
        public static void AddParameterOrNullUnchecked<T>(
            this SqlCommand @this,
            string parameterName,
            SqlDbType parameterType,
            T value)
        {
            @this.Parameters.AddParameterOrNullUnchecked(parameterName, parameterType, value, value != null);
        }

        public static void AddParameterOrNull<T>(
            this SqlCommand @this,
            string parameterName,
            SqlDbType parameterType,
            T value,
            bool condition)
        {
            Require.NotNull(@this, nameof(@this));

            @this.Parameters.AddParameterOrNullUnchecked(parameterName, parameterType, value, condition);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", MessageId = "0",
            Justification = "[Intentionally] This method clearly states that the responsibility for null-checks is on the callers.")]
        public static void AddParameterOrNullUnchecked<T>(
            this SqlCommand @this,
            string parameterName,
            SqlDbType parameterType,
            T value,
            bool condition)
        {
            @this.Parameters.AddParameterOrNullUnchecked(parameterName, parameterType, value, condition);
        }
    }
}