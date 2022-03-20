using CreciSP.Domain.Services.Booking;
using CreciSP.Domain.Services.Room;
using CreciSP.Domain.Services.User;
using CreciSP.Repository.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            #endregion

            #region Repositories
            services.AddScoped<IPersist, Persist>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            #endregion
        }
    }
}
