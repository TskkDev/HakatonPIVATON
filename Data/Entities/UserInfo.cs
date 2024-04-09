using HakatonPIVATON.Entity.Date;

namespace HakatonPIVATON.Data.Entities
{
    public class UserInfo
    {
        public UserInfo() { }
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; } = null!;
        public string FIO { get; set; } = null!;
        public DateTime BirthDate { get; set; }

    }
}
