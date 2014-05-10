﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.Windows.Forms
{
    using Narvalo.Mvp;

    public abstract class FormPresenter<TView> : Presenter<TView>, IFormPresenter<TView> 
        where TView : class, IView
    {
        protected FormPresenter(TView view) : base(view) { }

        public IMessageBus Messages { get; set; }

        public abstract void OnBindingComplete();
    }
}
