namespace CatchUpPlatform.API.News.Domain.Model.ValueObjects;

public sealed record SourceId
{
    private const int MaxLength = 255;
    
    public string Value { get; }

    public SourceId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Source cannot be null or whitespace.");
        }

        if (value.Length > MaxLength)
        {
            throw new ArgumentException("Source cannot be this long");
        }
    }
};