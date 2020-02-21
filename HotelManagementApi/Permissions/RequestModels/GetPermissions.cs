namespace HotelManagementApi.Permissions.RequestModels
{
    public class GetPermissions
    {
        public int? PermissionId { get; set; }
        public int? ParentId { get; set; }
        public int? Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IncludeDisabled { get; set; }
    }
}
