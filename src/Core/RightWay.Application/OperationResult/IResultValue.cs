namespace RightWay.Application.OperationResult;

internal interface IResultValue<TIn, TSelf> : IResult<TSelf>
    where TSelf : IResultValue<TIn, TSelf>
{
    public TIn? Value { get; }
    static abstract TSelf Success(TIn value);
}
