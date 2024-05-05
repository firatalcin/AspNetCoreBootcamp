using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ToDoAppNTier.Business.Interfaces;
using ToDoAppNTier.Business.Mappings.AutoMapper;
using ToDoAppNTier.Business.Services;
using ToDoAppNTier.Business.ValidationRules;
using ToDoAppNTier.DataAccess.Context;
using ToDoAppNTier.DataAccess.UnitOfWork;
using ToDoAppNTier.Dtos.WorkDtos;

namespace ToDoAppNTier.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {

            services.AddDbContext<ToDoContext>(opt =>
            {
                opt.UseSqlServer("server=MAKINA\\SQLEXPRESS01; database= ToDoAppDb; integrated security=true;TrustServerCertificate=True");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkService, WorkService>();

            services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateDtoValidator>();
        }
    }
}
