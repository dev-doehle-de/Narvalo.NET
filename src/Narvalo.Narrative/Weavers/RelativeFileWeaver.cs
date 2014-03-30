﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Narrative.Weavers
{
    using System.IO;
    using Narvalo.IO;
    using Narvalo.Narrative.IO;
    using Narvalo.Narrative.Templates;

    public sealed class RelativeFileWeaver : IWeaver<RelativeFile>
    {
        readonly IWeaverEngine<TemplateModel> _weaver;
        readonly IOutputWriter _writer;

        public RelativeFileWeaver(IWeaverEngine<TemplateModel> weaver, IOutputWriter writer)
        {
            Require.NotNull(weaver, "weaver");
            Require.NotNull(writer, "writer");

            _weaver = weaver;
            _writer = writer;
        }

        public void Weave(RelativeFile source)
        {
            Require.NotNull(source, "source");

            var model = new TemplateModel
            {
                Title = source.RelativeName,
            };

            string content;

            using (var reader = new StreamReader(source.File.FullName)) {
                content = _weaver.Weave(reader, model);
            }

            _writer.Write(source, content);
        }
    }
}
