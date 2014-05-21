﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.Resolvers
{
    using System;
    using System.Globalization;
    using System.Reflection.Emit;

    public class /*Default*/PresenterConstructorResolver : IPresenterConstructorResolver
    {
        public virtual DynamicMethod Resolve(Tuple<Type, Type> input)
        {
            Require.NotNull(input, "input");

            __Tracer.Info(this, @"Attempting to resolve ""{0}"".", input.Item1.FullName);

            var presenterType = input.Item1;
            var viewType = input.Item2;

            if (presenterType.IsNotPublic) {
                throw new ArgumentException(
                    String.Format(
                        CultureInfo.InvariantCulture,
                        "{0} does not meet accessibility requirements. For the WebFormsMvp framework to be able to call it, it must be public. Make the type public, or set PresenterBinder.Factory to an implementation that can access this type.",
                        presenterType.FullName),
                    "input");
            }

            var ctor = presenterType.GetConstructor(new[] { viewType });
            if (ctor == null) {
                throw new ArgumentException(
                    String.Format(
                        CultureInfo.InvariantCulture,
                        "{0} is missing an expected constructor, or the constructor is not accessible. We tried to execute code equivalent to: new {0}({1} view). Add a public constructor with a compatible signature, or set PresenterBinder.Factory to an implementation that can supply constructor dependencies.",
                        presenterType.FullName,
                        viewType.FullName),
                    "input");
            }

            // Using DynamicMethod and ILGenerator allows us to hold on to a
            // JIT-ed constructor call, which gives us an insanely fast way
            // to create type instances on the fly. This provides a surprising
            // performance improvement over basic reflection in applications
            // that create lots of presenters, which is common.
            var dynamicMethod = new DynamicMethod(
                "DynamicConstructor",
                presenterType,
                new[] { viewType },
                presenterType.Module,
                false /* skipVisibility */);

            var ilg = dynamicMethod.GetILGenerator();
            ilg.Emit(OpCodes.Nop);
            ilg.Emit(OpCodes.Ldarg_0);
            ilg.Emit(OpCodes.Newobj, ctor);
            ilg.Emit(OpCodes.Ret);

            return dynamicMethod;
        }
    }
}
