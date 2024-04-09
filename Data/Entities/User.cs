using HakatonPIVATON.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace HakatonPIVATON.Entity.Date
{
    public partial class User: IdentityUser<long>
    {
        public string Name { get; set; } = null!;
        public bool IsCompany { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public virtual ICollection<CompanyInfo> CompanyInfo { get; set; } = new List<CompanyInfo>();
        public virtual ICollection<UserInfo> UserInfo { get; set; } = new List<UserInfo>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<UsersGoods> UsersGoods { get; set; } = new List<UsersGoods>();
        public virtual ICollection<Point> Points { get; set; } = new List<Point>();
    }
}
