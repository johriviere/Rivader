using System.Net;

namespace Rivader.Domain.Core.Exceptions
{
    public interface IStatusCodeException
    {
        HttpStatusCode StatusCode { get; }
    }
}
