namespace HakatonPIVATON.Entity.Date
{
    public partial class OdersGoods
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int GoodId { get; set; }
        public Good Good { get; set; } = null!;
        public int CountGoods { get; set; }
    }
}
