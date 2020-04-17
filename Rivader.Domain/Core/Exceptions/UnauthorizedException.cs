using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace Rivader.Domain.Core.Exceptions
{
    public class UnauthorizedException : DomainException
    {
        public UnauthorizedException(string message)
            : base(message)
        {
        }

        private UnauthorizedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
    }
}
