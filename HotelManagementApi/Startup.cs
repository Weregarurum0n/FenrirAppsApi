using HotelManagementApi.Bookings.Repositories;
using HotelManagementApi.Bookings.Services;
using HotelManagementApi.Constants.Repositories;
using HotelManagementApi.Constants.Services;
using HotelManagementApi.Employees.Repositories;
using HotelManagementApi.Employees.Services;
using HotelManagementApi.Guests.Repositories;
using HotelManagementApi.Guests.Services;
using HotelManagementApi.Locations.Repositories;
using HotelManagementApi.Locations.Services;
using HotelManagementApi.Payments.Repositories;
using HotelManagementApi.Payments.Services;
using HotelManagementApi.Permissions.Repositories;
using HotelManagementApi.Permissions.Services;
using HotelManagementApi.Rooms.Repositories;
using HotelManagementApi.Rooms.Services;
using HotelManagementApi.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unity;

namespace HotelManagementApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

    }
    public static class HotelManagementDependencies
    {
        public static IServiceCollection RegisterHotelManagementDependencies(this IServiceCollection services)
        {
            services.AddTransient<IBookingsService, BookingsService>();
            services.AddTransient<IBookingsRepository, BookingsRepository>();

            services.AddTransient<IConstantsService, ConstantsService>();
            services.AddTransient<IConstantsRepository, ConstantsRepository>();

            services.AddTransient<IChangePasswordsService, ChangePasswordsService>();
            services.AddTransient<IChangePasswordsRepository, ChangePasswordsRepository>();

            services.AddTransient<IEmployeePermissionsService, EmployeePermissionsService>();
            services.AddTransient<IEmployeePermissionsRepository, EmployeePermissionsRepository>();

            services.AddTransient<IEmployeesService, EmployeesService>();
            services.AddTransient<IEmployeesRepository, EmployeesRepository>();

            services.AddTransient<IGuestsService, GuestsService>();
            services.AddTransient<IGuestsRepository, GuestsRepository>();

            services.AddTransient<ILocationsService, LocationsService>();
            services.AddTransient<ILocationsRepository, LocationsRepository>();

            services.AddTransient<IPaymentsService, PaymentsService>();
            services.AddTransient<IPaymentsRepository, PaymentsRepository>();

            services.AddTransient<IPermissionsService, PermissionsService>();
            services.AddTransient<IPermissionsRepository, PermissionsRepository>();

            services.AddTransient<IRoomsService, RoomsService>();
            services.AddTransient<IRoomsRepository, RoomsRepository>();

            return services;
        }
    }
}
