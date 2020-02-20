namespace HotelManagementApi.Locations.RequestModels
{
    public class SetCountry
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Abbrev { get; set; }
        public bool Disable { get; set; }
    }
}