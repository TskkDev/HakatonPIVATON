namespace HakatonPIVATON.Models.RespnseModel
{
    public class UserInfoResponse
    {
        public long Id { get; set; }
        public string? FIO { get; set; }
        public string? INN { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
