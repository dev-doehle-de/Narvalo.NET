﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.GhostScript.Internal
{
    internal static class NativeMethodsUtil
    {
        private const int SuccessCode_ = 0;
        // const int QuitCode = -101;
        // const int InterruptCode = ;
        // const int NeedInputCode = -106;
        // const int InfoCode = ;
        private const int FatalCode_ = -100;

        public static bool IsSuccess(int code)
        {
            // TODO: Often if GhostScript fails because you've passed the wrong combination of params etc,
            // it still returns zero... unhelpful
            return code == SuccessCode_;
        }

        public static bool IsError(int code)
        {
            return code < SuccessCode_;
        }

        // En cas d'erreur fatal il faut appeler tout de suite gsapi_exit()
        public static bool IsFatal(int code)
        {
            return code <= FatalCode_;
        }
    }
}
