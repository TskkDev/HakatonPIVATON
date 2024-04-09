using HakatonPIVATON.Entity.Date;

namespace HakatonPIVATON.Data.Entities
{
    public class CompanyInfo
    {
        public CompanyInfo() { }
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; } = null!;
        public string INN { get; set; } = null!;
    }
}
