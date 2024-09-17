

using System.Text.Json.Serialization;

namespace ECommerceSiteApi.Application.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public int DataTotalCount { get; set; }

        public static CustomResponseDto<T> Success(int statusCode, T data, int dataTotalCount)
        => new CustomResponseDto<T> {Data=data,StatusCode=statusCode,DataTotalCount=dataTotalCount };

        public static CustomResponseDto<T> Success(int statusCode,T data)
        =>new CustomResponseDto<T> { StatusCode=statusCode,Data=data };
        public static CustomResponseDto<T> Success(int statusCode)
        => new CustomResponseDto<T> {StatusCode=statusCode };

        public static CustomResponseDto<T> Fail(int statusCode, IEnumerable<string> errors)
        => new CustomResponseDto<T> {Errors=errors };

        public static CustomResponseDto<T> Fail(int statusCode, string error)
        => new CustomResponseDto<T> {Errors=new List<string> {error }};
    }
}
