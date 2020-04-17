using System.Net;
using System.Runtime.Serialization;

namespace Rivader.Domain.Core.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException(string message)
        : base(message)
        {
        }

        private NotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    }
}
