
namespace QuickBuck.MiddleWares
{
    public class CorsMiddleWare : IMiddleware
    {
        private readonly string _origin;

        public CorsMiddleWare(string origin)
        {
            _origin = origin;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", _origin);
            context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
            context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
            await next(context);

            ;
        }
    }
}
