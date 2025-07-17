using System.Diagnostics.CodeAnalysis;
using RightWay.Application.OperationResult;

namespace RightWay.Application;

public readonly struct Result<T> : IResultValue<T, Result<T>>
{
    public T? Value { get; }
    public Exception? Exception { get; }

    [MemberNotNullWhen(true, nameof(Value))] // indica ao compilador para se IsSuccess for true Value não é nulo
    [MemberNotNullWhen(false, nameof(Exception))] // indica ao compilador para se IsSuccess for false Exception não é nulo
    public bool IsSuccess { get; }

    public Result(T value)
    {
        IsSuccess = true;
        Exception = null;
        Value = value;
    }

    public Result(Exception exception)
    {
        Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        IsSuccess = false;
        Value = default;
    }

    public static implicit operator Result<T>(T value) => new Result<T>(value);

    public static implicit operator Result<T>(Exception exception) => new Result<T>(exception);

    static Result<T> IResult<Result<T>>.Success() => throw new NotImplementedException();

    static Result<T> IResultValue<T, Result<T>>.Success(T value) => new(value);

    static Result<T> IResult<Result<T>>.Error(Exception exception) => new(exception);
}
