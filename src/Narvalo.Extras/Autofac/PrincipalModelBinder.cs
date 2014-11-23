﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Autofac
{
    using System.Security.Principal;
    using System.Web.Mvc;
    using global::Autofac.Integration.Mvc;
    using Narvalo;

    [ModelBinderType(typeof(IPrincipal))]
    public class PrincipalModelBinder : IModelBinder
    {
        public object BindModel(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            Require.NotNull(controllerContext, "controllerContext");

            return controllerContext.HttpContext.User;
        }
    }
}