using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SimSDK.Interfaces;
using SimSDK.Services;
using Grpc.Reflection;
using Grpc.Reflection.V1Alpha;


namespace SamplePlugin
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPlugin, SamplePlugin>();
            services.AddGrpc();
            services.AddGrpcReflection();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GrpcPluginService>();
                endpoints.MapGrpcReflectionService();
            });
        }
    }
}