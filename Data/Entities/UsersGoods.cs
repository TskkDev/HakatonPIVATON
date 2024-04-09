namespace HakatonPIVATON.Entity.Date
{
    public partial class UsersGoods
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public long GoodId { get; set; }
        public virtual Good Good { get; set; } = null!;
        public long Remainder { get; set; } 
    }
}
