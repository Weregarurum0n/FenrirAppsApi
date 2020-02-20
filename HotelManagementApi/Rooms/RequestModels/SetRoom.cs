namespace HotelManagementApi.Rooms.RequestModels
{
    public class SetRoom
    {
        public int RoomId { get; set; }
        public int RoomNo { get; set; }
        public int RoomTypeId { get; set; }
        public decimal RoomRate { get; set; }
        public int RoomStatusId { get; set; }
        public int MaxCapacity { get; set; }
        public bool Disable {  get; set; }
    }
}