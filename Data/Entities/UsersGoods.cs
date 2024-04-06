namespace HakatonPIVATON.Entity.Date
{
    public partial class UsersGoods
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public int GoodId { get; set; }
        public virtual Good Good { get; set; } = null!;
        public int Remainder { get; set; } 
    }
}
