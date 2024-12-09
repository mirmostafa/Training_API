namespace Session07.Models;

public class Result
{
    public string? Error { get; init; }
    public bool IsSuccess { get; init; }

    public static Result Failure(string error) =>
        new()
        {
            IsSuccess = false,
            Error = error
        };

    public static Result Success() =>
        new()
        {
            IsSuccess = true,
        };
}

public class Result<T> : Result
{
    public T? Data { get; init; }

    public static new Result<T> Failure(string error) =>
        new()
        {
            IsSuccess = false,
            Error = error
        };

    public static Result<T> Success(T? data) =>
        new()
        {
            IsSuccess = true,
            Data = data
        };
}
