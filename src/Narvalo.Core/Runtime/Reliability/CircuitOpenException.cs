﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Runtime.Reliability
{
    using System;

    public class CircuitOpenException : BarrierException
    {
        public CircuitOpenException() : base() { }

        public CircuitOpenException(string message) : base(message) { }

        public CircuitOpenException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}