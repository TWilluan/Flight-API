

namespace API.Configuration.Exceptions;

public class NotFoundException : ApiException
{
    public NotFoundException() : base() {}
    public NotFoundException(string message) : base(message) {}
}