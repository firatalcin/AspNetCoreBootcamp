using IdentityApp.Web.Context;
using IdentityApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<IdentityContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("sqlLite"));
}).AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<IdentityContext>();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredLength = 6;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireDigit = false;

    opt.User.RequireUniqueEmail = true;
    //opt.User.AllowedUserNameCharacters = "abc"; 
    
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    opt.Lockout.MaxFailedAccessAttempts = 3;
    
    opt.SignIn.RequireConfirmedEmail = true;
});

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Account/Login";
    opt.LogoutPath = "/Account/Logout";
    opt.AccessDeniedPath = "/Account/AccessDenied";
    opt.SlidingExpiration = true;
    opt.ExpireTimeSpan = TimeSpan.FromDays(30);
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

SeedData.IdentityTestUser(app);

app.Run();