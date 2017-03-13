using System;
using System.Threading.Tasks;
using System.Web.Cors;
using Microsoft.Owin.Cors;
using Owin;

namespace AgeRanger.Cors
{
    public static class CrossOriginResourceSharing
    {
        public static IAppBuilder RegisterCors(this IAppBuilder app)
        {
            var policy = new CorsPolicy
            {
                AllowAnyOrigin = true,
                AllowAnyMethod = true /* Note: PUT and DELETE are not 'simple' methods */,
                SupportsCredentials = false,
                Methods = { "GET", "HEAD", "PUT", "POST", "DELETE", "PATCH", "OPTIONS" },
                PreflightMaxAge = TimeSpan.FromDays(1.0).Ticks / TimeSpan.TicksPerSecond,
            };

            app.UseCors(new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(policy)
                }
            });

            return app;
        }
    }
}