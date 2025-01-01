using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProductApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo() { Title = "BackEnd-Notes API", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddDbContext<ProductContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("sqlCon"));
});

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ProductContext>();
builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredLength = 6;
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;

    opt.User.RequireUniqueEmail = true;
    
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    opt.Lockout.MaxFailedAccessAttempts = 5;

});

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidIssuer = "firatalcin.com",
        ValidateAudience = false,
        ValidAudience = "",
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Key").Value ?? "")),
        ValidateLifetime = true

    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

