using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Middleware
{
    public class RequestTimeOutMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeOutMiddleware> _logger;
        private readonly Stopwatch _stopWatch;

        public RequestTimeOutMiddleware(ILogger<RequestTimeOutMiddleware> logger)
        {
            _logger = logger;
            _stopWatch = new Stopwatch();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopWatch.Start();
            await next.Invoke(context);
            _stopWatch.Stop();

            var elapsedMilliseconds = _stopWatch.ElapsedMilliseconds;
            if (elapsedMilliseconds / 1000 > 4)
            {
                var message =
                    $"Request [{context.Request.Method}] at {context.Request.Path} took {elapsedMilliseconds} ms";

                _logger.LogInformation(message);
            }
        }
    }
}
