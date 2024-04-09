namespace HakatonPIVATON.Models.RespnseModel
{
    public class UserInfoResponse
    {
        public long Id { get; set; }
        public string FIO { get; set; } = null!;
        public DateTime BirthDate { get; set; }
    }
}
