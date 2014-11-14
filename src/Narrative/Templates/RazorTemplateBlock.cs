﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narrative.Templates
{
    using System.Web;
    using Narrative.Parsers;

    public sealed class RazorTemplateBlock
    {
        public RazorTemplateBlock(BlockType blockType)
            : this(blockType == BlockType.Code) { }

        public RazorTemplateBlock(bool isCode)
        {
            IsCode = isCode;
        }

        public IHtmlString Content { get; set; }

        public bool IsCode { get; private set; }
    }
}