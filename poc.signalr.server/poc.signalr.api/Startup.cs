using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using poc.signalr.api.Hubs;

namespace poc.signalr.api {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {

            services.AddMvc();

            services.AddSignalR();

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", builder => {
                    builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:62214")
                        .AllowCredentials();
                });
            });

            //services.AddCors(options => {
            //    options.AddPolicy("CorsPolicy", builder => {
            //        builder.AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .AllowAnyOrigin()
            //            .AllowCredentials();
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseMvc();

            app.UseSignalR(routes => {
                routes.MapHub<ChatHub>("/chathub");
            });
        }
    }
}
