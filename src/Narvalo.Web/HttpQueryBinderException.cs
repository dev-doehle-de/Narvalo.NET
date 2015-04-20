﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web
{
    using System;
    using System.Runtime.Serialization;
    using System.Security;

    [Serializable]
    public class HttpQueryBinderException : Exception
    {
        private string _memberName = String.Empty;

        public HttpQueryBinderException() { }

        public HttpQueryBinderException(string message) : base(message) { }

        public HttpQueryBinderException(string message, Exception innerException)
            : base(message, innerException) { }

        protected HttpQueryBinderException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public string MemberName { get { return _memberName; } set { _memberName = value; } }

        [SecurityCritical]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("MemberName", _memberName);
        }
    }
}
