namespace NetCoreVolunteering.Domain.Shared;

public class Error
{
    private Error(string code, string message, ErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }

    public string Code { get; }
    public string Message { get; }
    public ErrorType Type { get; }

    public static Error Validation(string code, string message) =>
        new Error(code, message, ErrorType.Validation);
    
    public static Error NotFound(string code, string message) =>
        new Error(code, message, ErrorType.NotFound);
    
    public static Error Failure(string code, string message) =>
        new Error(code, message, ErrorType.Failure);
    
    public static Error Conflict(string code, string message) =>
        new Error(code, message, ErrorType.Conflict);
}