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
using HotelManagementApi.Login.Repositories;
using HotelManagementApi.Login.Services;
using HotelManagementApi.Payments.Repositories;
using HotelManagementApi.Payments.Services;
using HotelManagementApi.Permissions.Repositories;
using HotelManagementApi.Permissions.Services;
using HotelManagementApi.Ping;
using HotelManagementApi.Rooms.Repositories;
using HotelManagementApi.Rooms.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagementApi
{
    public static class HotelManagementIoc
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

            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<ILoginRepository, LoginRepository>();

            services.AddTransient<IPaymentsService, PaymentsService>();
            services.AddTransient<IPaymentsRepository, PaymentsRepository>();

            services.AddTransient<IPermissionsService, PermissionsService>();
            services.AddTransient<IPermissionsRepository, PermissionsRepository>();

            services.AddTransient<IPingHotelManagement, PingHotelManagement>();

            services.AddTransient<IRoomsService, RoomsService>();
            services.AddTransient<IRoomsRepository, RoomsRepository>();

            return services;
        }
    }
}
