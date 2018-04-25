using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace InventoryModule
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddOptions();
           // services.AddAntiforgery(o =>  o.HeaderName= "X-MY-TOKEN");
            services.AddMvc();
            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            services.AddDbContext<Models.InventoryContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //DP for Masters

            services.AddTransient<Interfaces.IProductGroup, Data.ProductGroupRepository>();
            services.AddTransient<Interfaces.IUnitOfMeasure, Data.UnitOfMeasureRepository>();
            services.AddTransient<Interfaces.IProductInterface,Data.ProductRepository>();
            services.AddTransient<Interfaces.ILedgerGroup, Data.LedgerGroupRepository>();
            services.AddTransient<Interfaces.ILedger, Data.LedgerRepository>();
        }

        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Microsoft.AspNetCore.Antiforgery.IAntiforgery antiforgery)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            //app.Use(next => httpContext =>
            //{
            //    AntiforgeryTokenSet tokenSet = antiforgery.GetAndStoreTokens(httpContext);
            //    httpContext.Response.Cookies.Append(
            //        "MY-TOKEN",
            //        tokenSet.RequestToken,
            //        new CookieOptions() { HttpOnly = false }
            //    );
            //    return next(httpContext);
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Ledger}/{action=Index}/{id?}");
            });
        }
    }
}
