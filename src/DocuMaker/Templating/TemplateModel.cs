﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace DocuMaker.Templating
{
    using System.Collections.Generic;
    using DocuMaker.Parsing;

    public sealed class TemplateModel : ITemplateModel
    {
        public IEnumerable<Block> Blocks { get; set; }

        public string Title { get; set; }
    }
}