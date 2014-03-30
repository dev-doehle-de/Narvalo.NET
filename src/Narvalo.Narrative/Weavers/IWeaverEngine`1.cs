﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Narrative.Weavers
{
    using System.IO;
    using Narvalo.Narrative.Templates;

    public interface IWeaverEngine<TModel> where TModel : ITemplateModel
    {
        string Weave(TextReader reader, TModel model);
    }
}
