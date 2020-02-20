using HotelManagementApi.Bookings.Services;
using Unity;

namespace HotelManagementApi
{
    public class HotelManagementIoc
    {
        public HotelManagementIoc()
        {
            IUnityContainer container = new UnityContainer();

            OnRegister(container);
        }

        public void OnRegister(IUnityContainer container)
        {
            container.RegisterType<IBookingsService, BookingsService>();
        }
    }
}
