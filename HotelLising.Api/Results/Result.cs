using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HotelLising.Api.Results
{
    public class Result<TData> : ICustomResult
    {
        public bool IsSuccess { get; set; }

        public int StatusCode {get;set;}

        public string Message { get; set; } = string.Empty;

        public object? Error { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public TData? Data { get; set; }
        public static Result<TData> Create(bool isSuccess,
                                           int statusCode,
                                           string message,
                                           TData? data = default!,
                                           object? errors = null)
        {
            return new Result<TData>
            {
                IsSuccess = isSuccess,
                StatusCode = statusCode,
                Message = message,
                Data = data,
                Error = errors
            };
        }

        
        public static Result<TData> Ok(TData? data, string message)
        {
            return Create(isSuccess: true,
                          data: data,
                          statusCode: StatusCodes.Status200OK,
                          message: message);
        }


        public static Result<TData> NotFound(string message)
        {
            return Create(isSuccess: false,
                          statusCode: StatusCodes.Status404NotFound,
                          message: message);
        }

        public static Result<TData> Conflict(string message)
        {
            return Create(isSuccess: false,
                          statusCode: StatusCodes.Status409Conflict,
                          message: message);
        }

        public static Result<TData> CreatedAt(string message)
        {
            return Create(isSuccess: true,
                          statusCode: StatusCodes.Status201Created,
                          message: message);
        }

        public static Result<TData> BadRequest(string message)
        {
            return Create(isSuccess: false,
                          statusCode: StatusCodes.Status400BadRequest,
                          message: message);
        }
    }
}
