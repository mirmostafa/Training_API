using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public abstract class ResultBase
{
    public bool IsSucceed { get; init; }
    public string? Message { get; init; }
}

public sealed class Result: ResultBase
{
    public static Result Success()
    {
        return new Result { IsSucceed = true };
    }

    public static Result Fail(string message)
    {
        return new Result { IsSucceed = false, Message = message };
    }
}

public sealed class Result<TValue> : ResultBase
{
    public TValue? Value { get; init; }
    public static Result<TValue> Success(TValue value)
    {
        return new Result<TValue> { IsSucceed = true, Value = value };
    }
    public static Result<TValue> Fail(string message)
    {
        return new Result<TValue> { IsSucceed = false, Message = message };
    }
}