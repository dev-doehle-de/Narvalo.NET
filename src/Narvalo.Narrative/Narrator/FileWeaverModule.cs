﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Narrative.Narrator
{
    using System.IO;
    using Autofac;
    using Narvalo.IO;
    using Narvalo.Narrative.Internal;
    using Narvalo.Narrative.Weavers;

    public sealed class FileWeaverModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Require.NotNull(builder, "builder");

            // FIXME: Automation for interception?
            builder.RegisterType<FileWeaverInterceptor>().AsSelf();
            builder.RegisterType<RelativeFileWeaverInterceptor>().AsSelf();

            // Absolute file weaver.
            builder.RegisterType<FileWeaver>()
                .As<IWeaver<FileInfo>>()
                .InterfaceDebuggedBy(typeof(FileWeaverInterceptor));

            // Relative file weaver (used by DirectoryWeaver).
            builder.RegisterType<RelativeFileWeaver>()
                .As<IWeaver<RelativeFile>>()
                .InterfaceDebuggedBy(typeof(RelativeFileWeaverInterceptor));
        }
    }
}
