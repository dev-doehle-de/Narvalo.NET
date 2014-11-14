﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web.Mvp
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Web.UI;
    using Narvalo.Mvp;
    using Narvalo.Web.Mvp.Core;

    public abstract class MvpUserControl : UserControl, IView
    {
        readonly bool _throwIfNoPresenterBound;

        bool _autoDataBind = true;

        protected MvpUserControl() : this(true) { }

        protected MvpUserControl(bool throwIfNoPresenterBound)
        {
            _throwIfNoPresenterBound = throwIfNoPresenterBound;
        }

        public bool ThrowIfNoPresenterBound
        {
            get { return _throwIfNoPresenterBound; }
        }

        protected bool AutoDataBind
        {
            get { return _autoDataBind; }
            set { _autoDataBind = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            PageHost.Register(Page, Context).RegisterView(this);

            if (AutoDataBind) {
                Page.PreRenderComplete += (sender, args) => DataBind();
            }

            base.OnInit(e);
        }

        protected T DataItem<T>()
            where T : class, new()
        {
            var t = Page.GetDataItem() as T;
            return t ?? new T();
        }

        protected T DataValue<T>()
        {
            return (T)Page.GetDataItem();
        }

        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "FIXME")]
        protected string DataValue<T>(string format)
        {
            return String.Format(CultureInfo.CurrentCulture, format, (T)Page.GetDataItem());
        }
    }
}