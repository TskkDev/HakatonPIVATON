namespace HakatonPIVATON.Entity.Date
{
    public partial class OdersGoods
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public long GoodId { get; set; }
        public Good Good { get; set; } = null!;
        public long CountGoods { get; set; }
    }
}
