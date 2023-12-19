

namespace API.Configuration.Exceptions;

public class NotFoundApiException : ApiException
{
    public NotFoundApiException() : base() {}
    public NotFoundApiException(string message) : base(message) {}
}