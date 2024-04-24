namespace MvcBasic.Middlewares
{
    public class RequestEditingMiddleware
    {
        private RequestDelegate _requestDelegate;

        public RequestEditingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString() == "/firat")
            {
                await context.Response.WriteAsync("Hoşgeldin Fırat");
            }
            else
            {
                await _requestDelegate.Invoke(context);
            }
            
        }
    }
}
