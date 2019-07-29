using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Sampekey.Middleware
{
    public static class SampekeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseSampeKey(this IApplicationBuilder app)
        {
            return app;
        }

    }
}