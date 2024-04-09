namespace HakatonPIVATON.Models.RespnseModel
{
    public class UserResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public UserInfoResponse? UserInfo { get; set; }
        public CompanyInfoResponse? CompanyInfo { get; set; }
        public List<GoodResponse> Goods { get; set; } = new List<GoodResponse>();
        public List<OrderResponse> Order { get; set; } = new List<OrderResponse>();
    }
}
