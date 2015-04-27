﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Prose.IO
{
    using System.IO;
    using Narvalo.IO;

    public interface IPathProvider
    {
        string GetDirectoryPath(RelativeDirectory directory);

        string GetFilePath(RelativeFile file);

        string GetFilePath(FileInfo file);
    }
}