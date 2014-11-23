﻿namespace Narvalo.Reliability
{
    using System;

    public class CircuitBreakerStateChangedEventArgs : EventArgs
    {
        readonly CircuitBreakerState _lastState;
        readonly CircuitBreakerState _newState;

        public CircuitBreakerStateChangedEventArgs(
            CircuitBreakerState lastState,
            CircuitBreakerState newState)
        {
            _lastState = lastState;
            _newState = newState;
        }

        public CircuitBreakerState LastState
        {
            get { return _lastState; }
        }

        public CircuitBreakerState NewState
        {
            get { return _newState; }
        }
    }
}