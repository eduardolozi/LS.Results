using LS.Results.Interfaces;
using LS.Results.Models;
using Microsoft.AspNetCore.Mvc;

namespace LS.Results.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result, IErrorMapper mapper) where T : class
    {
        if (result.IsSuccess)
            return new OkObjectResult(result.Value);

        var statusCode = mapper.GetHttpStatusCode(result.Error!);

        var problemDetails = new ProblemDetails
        {
            Title = "An error occurred.",
            Detail = result.Error!.Message,
            Status = statusCode,
            Type = result.Error.Code
        };

        return new ObjectResult(problemDetails)
        {
            StatusCode = statusCode
        };
    }
}