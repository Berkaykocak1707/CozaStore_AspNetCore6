namespace CozaStore_AspNetCore6.Infrastructure.Extensions
{
    public static class HttpRequestExtension
    {
        public static string PathAndQuery(this HttpRequest request)
        {
            return request.QueryString.HasValue
                ? $"{request.Path}{request.QueryString}"
                : request.Path.ToString();
        }
        //@ViewContext.HttpContext.Request.PathAndQuery() use it
    }
}
