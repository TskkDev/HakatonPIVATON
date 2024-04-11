namespace HakatonPIVATON.Models.RequestModel
{
    public class UserRequest
    {
        public string Name { get; set; } = null!;
        public long? UserInfoId { get; set; }
        public long? CompanyInfoId { get; set; }
        public List<long> GoodsId { get; set; } = new List<long>();
        public List<long> OrderId { get; set; } = new List<long>();
    }
}
