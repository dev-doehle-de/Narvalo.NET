﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.Windows.Forms
{
    public interface IFormPresenter<TView>
        : IPresenter<TView>, IFormPresenter where TView : IView { }
}
