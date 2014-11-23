﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.DocuMaker.Internal
{
    using System.IO;
    using Castle.DynamicProxy;
    using Narvalo;
    using Serilog;

    internal sealed class FileWeaverInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Require.NotNull(invocation, "invocation");

            var info = invocation.Arguments[0] as FileSystemInfo;

            Log.Debug("Processing {Name}", info.FullName);

            invocation.Proceed();
        }
    }
}
