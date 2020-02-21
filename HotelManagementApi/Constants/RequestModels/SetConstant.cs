namespace HotelManagementApi.Constants.RequestModels
{
    public class SetConstant
    {
        public int? ConstantId { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Disable { get; set; }
    }
}