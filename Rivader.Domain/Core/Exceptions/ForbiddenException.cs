using System;
using System.Net;
using System.Runtime.Serialization;

namespace Rivader.Domain.Core.Exceptions
{
    [Serializable]
    public class ForbiddenException : DomainException
    {
        public ForbiddenException(string message)
            : base(message)
        {
        }

        private ForbiddenException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;
    }
}
