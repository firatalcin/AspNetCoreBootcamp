
using Microsoft.EntityFrameworkCore;
using WebAPI.CQRS.Handlers;
using WebAPI.Data;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddScoped<GetStudentGetByIdQueryHandler>();
            //builder.Services.AddScoped<GetStudentsQueryHandler>();
            //builder.Services.AddScoped<CreateStudentCommandHandler>();
            //builder.Services.AddScoped<RemoveStudentCommandHandler>();
            //builder.Services.AddScoped<UpdateStudentCommandHandler>();
            builder.Services.AddMediatR(opt =>
            {
                opt.RegisterServicesFromAssemblyContaining(typeof(Program));
            });

            builder.Services.AddDbContext<StudentContext>(opt =>
            {
                opt.UseSqlServer("server=MAKINA\\SQLEXPRESS01; database= StudentDb; integrated security=true;TrustServerCertificate=True");
            });

            builder.Services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
