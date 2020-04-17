using System.Net;
using System.Runtime.Serialization;

namespace Rivader.Domain.Core.Exceptions
{
    public class BadRequestException : DomainException
    {
        public BadRequestException(string message)
            : base(message)
        {
        }

        private BadRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}
