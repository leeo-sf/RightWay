using System.Diagnostics.CodeAnalysis;
using RightWay.Application.OperationResult;

namespace RightWay.Application;

public struct Result : IResult<Result>
{
    public Exception? Exception { get; }

    [MemberNotNullWhen(false, nameof(Exception))] // indica ao compilador para se IsSuccess for false Exception não é nulo
    public bool IsSuccess { get; }

    public Result(bool success)
    {
        IsSuccess = success;
        Exception = null;
    }

    public Result(Exception exception)
    {
        Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        IsSuccess = false;
    }

    public static Result Success() => new(true);

    public static Result Error(Exception error) => new(error);

    public static Result<T> Success<T>(T value) => new(value);

    public static Result<T> Error<T>(Exception error) => new(error);
}
