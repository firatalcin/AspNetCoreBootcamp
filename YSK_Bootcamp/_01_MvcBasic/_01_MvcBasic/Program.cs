using MvcBasic.Middlewares;

namespace _01_MvcBasic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseExceptionHandler("/Home/Error");

            app.UseStatusCodePagesWithReExecute("/Home/Status", "?code={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            

            app.UseRouting();
            app.UseSession();

            //app.UseMiddleware<ResponseEditingMiddleware>();
            //app.UseMiddleware<RequestEditingMiddleware>();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{Area}/{Controller=Home}/{Action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
