namespace DTO_QuanLy
{
    public class UserType_Data
    {
        public string name { get; set; }
        public int expiration_time { get; set; }
        public int maximum_borrows { get; set; }
        public int borrow_time { get; set; }
        public float lost_percentage { get; set; }
        public float damaged_percentage { get; set; }
        public int extend_time { get; set; }
        public long price { get; set; }
        public UserType_Data()
        {
            name = "System trial";
        }
    }
}
