namespace meetroomreservation.Data.RequestModel
{
    public class UserUpdatePasswordRequestModel
    {
        public int Id { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}