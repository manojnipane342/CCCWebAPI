namespace CCCWebAPI.ApiShare
{
    public class ActionResponse<T>
    {
        public int code { get; set; }
        public bool hasError { get; set; }
        public string responseMessage { get; set; }
        public T responseData { get; set; }
        public ActionResponse(bool _hasError, string msg, T _data, int statusCode)
        {
            hasError = _hasError;
            responseMessage = msg;
            responseData = _data;
            code = statusCode;
        }
    }
}
