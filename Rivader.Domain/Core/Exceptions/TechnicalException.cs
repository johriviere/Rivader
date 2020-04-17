using System.Net;
using System.Runtime.Serialization;

namespace Rivader.Domain.Core.Exceptions
{
    public class TechnicalException : DomainException
    {
        public TechnicalException(string message)
            : base(message)
        {
        }

        private TechnicalException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
    }
}
