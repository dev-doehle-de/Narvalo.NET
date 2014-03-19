﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Narrative
{
    using Narvalo.IO;

    public sealed class NoopWriter : IOutputWriter
    {
        public void CreateDirectory(RelativeDirectory directory)
        {
            // Intentionally left blank.
        }

        public void Write(RelativeFile file, string content)
        {
            // Intentionally left blank.
        }
    }
}
