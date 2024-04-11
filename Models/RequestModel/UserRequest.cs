namespace HakatonPIVATON.Models.RequestModel
{
    public class UserRequest
    {
        public string Name { get; set; } = null!;
        public bool IsCompany { get; set; }
        public UserInfoRequest UserInfo { get; set; } = null!;
    }
}
