using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.API.Response;

public record Envelope
{
    private Envelope(object? result, IEnumerable<ResponseError> errors)
    {
        Result = result;
        Errors = errors.ToList();
        TimeGenerated = DateTime.Now;
    }

    public object? Result { get; }
    public List<ResponseError> Errors { get; }
    public DateTime TimeGenerated { get; }

    public static Envelope Ok(object? result = null) =>
        new Envelope(result, null);
    
    public static Envelope Error(IEnumerable<ResponseError> errors) =>
        new Envelope(null, errors);
};