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
            services.AddScoped<IRequestInfo, RequestInfo>();

            using (IUnityContainer container = new UnityContainer())
            {
                container.RegisterType<IBookingsService, BookingsService>();
                container.RegisterType<IBookingsRepository, BookingsRepository>();

                container.RegisterType<IConstantsService, ConstantsService>();
                container.RegisterType<IConstantsRepository, ConstantsRepository>();

                container.RegisterType<IChangePasswordsService, ChangePasswordsService>();
                container.RegisterType<IChangePasswordsRepository, ChangePasswordsRepository>();

                container.RegisterType<IEmployeePermissionsService, EmployeePermissionsService>();
                container.RegisterType<IEmployeePermissionsRepository, EmployeePermissionsRepository>();

                container.RegisterType<IEmployeesService, EmployeesService>();
                container.RegisterType<IEmployeesRepository, EmployeesRepository>();

                container.RegisterType<IGuestsService, GuestsService>();
                container.RegisterType<IGuestsRepository, GuestsRepository>();

                container.RegisterType<ILocationsService, LocationsService>();
                container.RegisterType<ILocationsRepository, LocationsRepository>();

                container.RegisterType<IPaymentsService, PaymentsService>();
                container.RegisterType<IPaymentsRepository, PaymentsRepository>();

                container.RegisterType<IPermissionsService, PermissionsService>();
                container.RegisterType<IPermissionsRepository, PermissionsRepository>();

                container.RegisterType<IRoomsService, RoomsService>();
                container.RegisterType<IRoomsRepository, RoomsRepository>();
            }
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
}
