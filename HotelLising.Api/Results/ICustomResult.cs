namespace HotelLising.Api.Results
{
    public interface ICustomResult
    {
        bool IsSuccess { get; }
        int StatusCode { get; }
        string Message { get; }
        object? Error { get; }
        DateTime TimeStamp { get; }
    }
}
