using System.Net;

namespace Rivader.Domain.Core.Exceptions
{
    /// <summary>
    /// HttpStatusCode exposition for domain exceptions
    /// </summary>
    public interface IStatusCodeException
    {
        HttpStatusCode StatusCode { get; }
    }
}
