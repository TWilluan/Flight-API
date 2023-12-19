

namespace API.Configuration.Exceptions;

public class ForbiddenApiException : ApiException
{
    public ForbiddenApiException() : base() { }
    public ForbiddenApiException(string message) : base(message)
    {
    }
}