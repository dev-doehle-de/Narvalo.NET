﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Runtime.Reliability
{
    using System;

    public class RequestCounter : ISentinel, IReliabilityMonitor
    {
        private long _failureCount = 0;
        private long _requestCount = 0;
        private long _successCount = 0;

        #region IGuard

        public void Execute(Action action)
        {
            Require.NotNull(action, "action");

            RecordRequest();

            try
            {
                action.Invoke();
            }
            catch (GuardException)
            {
                throw;
            }
            catch
            {
                RecordFailure();
                throw;
            }

            RecordSuccess();
        }

        #endregion

        #region IReliabilityMonitor

        public long FailureCount
        {
            get { return _failureCount; }
        }

        public long RequestCount
        {
            get { return _requestCount; }
        }

        public long SuccessCount
        {
            get { return _successCount; }
        }

        public void RecordFailure()
        {
            _failureCount++;
        }

        public void RecordRequest()
        {
            _requestCount++;
        }

        public void RecordSuccess()
        {
            _successCount++;
        }

        #endregion
    }
}
