namespace CatchUpPlatform.API.Shared.Application.Patterns;

public abstract record Result<TValue, TError>
{
    public sealed record Success(TValue Value) : Result<TValue, TError>;

    public sealed record Failure(TValue Value) : Result<TValue, TError>;

    public bool IsSuccess => this is Success;
    public bool IsFailure => this is Failure;

    public Result<TNext, TError> Map<TNext>(Func<TValue, TNext> onSuccess) => this switch
    {
        Success success => new Result<TValue, TError>.Success(onSuccess(success.Value)),
        Failure failure => new Result<TValue, TError>.Failure(failure.error),
        _ => throw new InvalidOperationException("Invalid result type")
    };

    public void Match(Action<TValue> onSuccess, Action<TValue> onFailure)
    {
        switch (this)
        {
            case Success success:
                onSuccess(success.Value);
                break;
            case Failure failure:
                onFailure(failure.Error);
                break;
            default:
                throw new InvalidOperationException("Invalid result type");
        }
    }


}