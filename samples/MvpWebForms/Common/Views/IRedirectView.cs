﻿namespace MvpWebForms.Views
{
    using System;
    using Narvalo.Mvp;

    public interface IRedirectView : IView
    {
        event EventHandler ActionAccepted;
    }
}