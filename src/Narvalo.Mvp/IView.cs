﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp
{
    using System;

    public interface IView
    {
        bool ThrowIfNoPresenterBound { get; }

        event EventHandler Load;
    }
}
