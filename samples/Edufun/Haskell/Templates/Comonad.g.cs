﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
//
// Runtime Version: 4.0.30319.42000
// Microsoft.VisualStudio.TextTemplating: 14.0
// </auto-generated>
//------------------------------------------------------------------------------

using global::Narvalo;
using global::Narvalo.Fx;

namespace Edufun.Haskell.Templates
{
    // Implements core Comonad methods.
    public static partial class Comonad
    {
        /// <remarks>
        /// Named <c>extract</c> in Haskell parlance.
        /// </remarks>
        public static T Extract<T>(Comonad<T> value)
            /* T4: type constraint */
        {
            Expect.NotNull(value);

            return Comonad<T>.ε(value);
        }

        /// <remarks>
        /// Named <c>duplicate</c> in Haskell parlance.
        /// </remarks>
        public static Comonad<Comonad<T>> Duplicate<T>(Comonad<T> value)
            /* T4: type constraint */
        {
            Warrant.NotNull<Comonad<Comonad<T>>>();

            return Comonad<T>.δ(value);
        }
    } // End of Comonad - T4: EmitComonadCore().
}
