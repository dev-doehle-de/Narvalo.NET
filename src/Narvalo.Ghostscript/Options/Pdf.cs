﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.GhostScript.Options
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class Pdf
    {
        private int? _firstPage;
        private int? _lastPage;
        private bool _noUserInit = false;
        private string _password;
        private bool _renderTTNotDef = false;
        private bool _showAcroForm = false;
        private bool _showAnnotations = true;

        public Pdf() : base() { }

        public int? FirstPage { get { return _firstPage; } set { _firstPage = value; } }

        public int? LastPage { get { return _lastPage; } set { _lastPage = value; } }

        public bool NoUserInit { get { return _noUserInit; } set { _noUserInit = value; } }

        public string Password { get { return _password; } set { _password = value; } }

        public bool RenderTTNotDef { get { return _renderTTNotDef; } set { _renderTTNotDef = value; } }

        public bool ShowAcroForm { get { return _showAcroForm; } set { _showAcroForm = value; } }

        public bool ShowAnnotations { get { return _showAnnotations; } set { _showAnnotations = value; } }

        public void AddTo(ICollection<string> args)
        {
            Require.NotNull(args, "args");

            if (!String.IsNullOrEmpty(Password))
            {
                args.Add("-sPDFPassword=" + Password);
            }

            if (FirstPage.HasValue)
            {
                args.Add("-dFirstPage=" + FirstPage.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (LastPage.HasValue)
            {
                args.Add("-dLastPage=" + LastPage.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (!ShowAnnotations)
            {
                args.Add("-dShowAnnots=false");
            }

            if (ShowAcroForm)
            {
                args.Add("-dShowAcroForm");
            }

            if (NoUserInit)
            {
                args.Add("-dNoUserUnit");
            }

            if (RenderTTNotDef)
            {
                args.Add("-dRENDERTTNOTDEF");
            }
        }
    }
}
