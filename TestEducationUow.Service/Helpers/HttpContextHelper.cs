using Microsoft.AspNetCore.Http;

namespace TestEducationCenterUoW.Service.Helpers
{
    public class HttpContextHelper
    {
        public static IHttpContextAccessor Accessor;
        public static HttpContext Context => Accessor?.HttpContext;
        public static IHeaderDictionary ResponseHeaders => Context?.Response?.Headers;
        public static string Language => Context?.Request?.Headers["Accept-Language"].ToString();

    }
}
