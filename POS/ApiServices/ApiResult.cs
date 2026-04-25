namespace POS.ApiServices
{
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }

        public static ApiResult<T> Ok(T data)
        {
            return new ApiResult<T> { Success = true, Data = data };
        }

        public static ApiResult<T> Fail(string errorMessage)
        {
            return new ApiResult<T> { Success = false, ErrorMessage = errorMessage };
        }
    }
}
