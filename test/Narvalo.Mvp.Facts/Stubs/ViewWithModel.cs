﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.Stubs
{
    using System;

    public class ViewWithModel : IView<ViewModel>
    {
        event EventHandler IView.Load
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        public ViewModel Model { get; set; }

        public bool ThrowIfNoPresenterBound
        {
            get { throw new NotImplementedException(); }
        }
    }
}
