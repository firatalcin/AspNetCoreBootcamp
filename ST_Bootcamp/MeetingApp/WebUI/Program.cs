namespace WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "Default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            app.Run();
        }
    }
}
