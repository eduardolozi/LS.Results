using LS.Results.Models;

namespace LS.Results.Interfaces;

public interface IErrorMapper
{
    public int GetHttpStatusCode(Error error);
}