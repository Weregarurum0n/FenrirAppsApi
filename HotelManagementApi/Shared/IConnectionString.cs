namespace HotelManagementApi.Shared
{
    public interface IConnectionString
    {
        string DataSource { get; set; }
        string InitialCatalog { get; set; }
        string UserId { get; set; }
        string Password { get; set; }
        string Conn { get; set; }
    }
}
