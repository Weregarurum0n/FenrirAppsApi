namespace HotelManagementApi.Locations.RequestModels
{
    public class SetCity
    {
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Abbrev { get; set; }
        public bool Disable { get; set; }
    }
}
