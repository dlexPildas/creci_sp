using CreciSP.Domain.Services.BookingRepository;
using CreciSP.Application.Services.BookingService;
using CreciSP.Domain.Services.RoomRepository;
using CreciSP.Application.Services.RoomService;
using CreciSP.Domain.Services.UserRepository;
using CreciSP.Application.Services.UserService;
using CreciSP.Repository.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using _03.CreciSP.Domain.Notifier;
using CreciSP.Domain.Services.LogNotifyRepository;
using CreciSP.Application.Services.LogNotifyService;
using CreciSP.Application.Services.EquipmentService;
using CreciSP.Domain.Services.EquipmentRepository;

namespace CreciSP.CrossCutting
{
    public class DependencyInjection
    {
        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ILogNotifyService, LogNotifyService>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            #endregion

            #region Repositories
            services.AddScoped<IPersist, Persist>(); 
            services.AddScoped<IReadConnection, ReadConnection>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ILogNotifyRepository, LogNotifyRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            #endregion

            services.AddScoped<INotifierService, NotifierService>();

            //services.RegisterAssemblyTypes(typeof(INotifierService).Assembly)
            //    .AsSelf()
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();

            //services.Scan(scan => scan
            //    .FromAssemblies(typeof(yourassembly).GetTypeInfo().Assembly)
            //    .AddClasses()
            //    .AsImplementedInterfaces()
            //    .WithScopedLifetime());
        }
    }
}
