using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using SkinDesign.Interfaces;
using SkinDesign.Services;
using SkinDesign.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SkinDesign.Entities;

namespace SkinDesign
{
    public class Startup
    {
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables();

            _config = builder.Build();
        }

        //public IConfiguration Configuration { get; set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IProceduresData, ProceduresData>();
            services.AddDbContext<SkinDesignDbContext>(options =>
                options.UseSqlServer(_config.GetConnectionString("SkinDesign_db")));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<SkinDesignDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();

            app.UseNodeModules(env.ContentRootPath);

            app.UseIdentity();

            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default",
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
