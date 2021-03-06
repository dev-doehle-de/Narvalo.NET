﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Mvp.PresenterBinding
{
    using System.Collections.Generic;

    public partial interface IPresenterDiscoveryStrategy
    {
        PresenterDiscoveryResult FindBindings(IEnumerable<object> hosts, IEnumerable<IView> views);
    }
}
