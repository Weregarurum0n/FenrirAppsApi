namespace HotelManagementApi.Shared
{
    public class ConnectionString : IConnectionString
    {
        public string DataSource { get => "LAPTOP-K2EH8V3O"; set { } }
        public string InitialCatalog { get => "HotelManagement"; set { } }
        public string UserId { get => "sa"; set { } }
        public string Password { get => "coventry"; set { } }

        public string Conn { get => "Data Source=" + DataSource + ";Initial Catalog=" + InitialCatalog + ";User ID=" + UserId + ";Password=" + Password + ";"; set { } }
    }
}
