namespace HakatonPIVATON.Models.RespnseModel
{
    public class UserResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsCompany { get; set; }
        public List<UserInfoResponse> UserInfo { get; set; } = new List<UserInfoResponse>();
        public List<GoodResponse> Goods { get; set; } = new List<GoodResponse>();
        public List<OrderResponse> Order { get; set; } = new List<OrderResponse>();
    }
}
