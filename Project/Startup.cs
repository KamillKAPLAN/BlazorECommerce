using BlazorECommerce.DependencyInjection;
using BlazorECommerce.Stores.CounterStore;
using eShop.DataStore.HardCoded;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.SearchProductScreen;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazorECommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISearchProduct, SearchProduct>();
            services.AddTransient<IViewProduct, ViewProduct>();

            services.AddScoped<CounterStore>();

            /* Ýlk uygulama çalýþtýðýnda, Sayfa F5 yapýldýðýnda ve Componentler arasýnda deðiþim olduðunda çalýþýr. */
            // services.AddTransient<ICustomerService, CustomerService>();

            /* Ýlk uygulama çalýþtýðýnda bir kere çalýþýr. */
            services.AddSingleton<ICustomerService, CustomerService>();

            /* Ýlk uygulama çalýþtýðýnda ve Sayfa F5 yapýldýðýnda çalýþýr. */
            // services.AddScoped<ICustomerService, CustomerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
