using WebCalculatorWithDI.CalcExpressionTreeBuilder;
using WebCalculatorWithDI.Controllers;

namespace WebCalculatorWithDI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IExpressionCalculator, ExpressionCalculator>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _ = env.IsDevelopment()
                ? app.UseDeveloperExceptionPage()
                : app.UseExceptionHandler("/Home/Error").UseHsts();

            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        "default",
                        "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}
