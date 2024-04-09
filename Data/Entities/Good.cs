namespace HakatonPIVATON.Entity.Date
{
    public partial class Good
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Pic { get; set; } = null!;
        public decimal Price { get; set; }
        public double Weigh { get; set;}
        public string Description { get; set; } = null!;
        public virtual ICollection<UsersGoods> UsersGoods { get; set; } = new List<UsersGoods>();
        public virtual ICollection<OdersGoods> OdersGoods { get; set; } = new List<OdersGoods>();

    }
}
