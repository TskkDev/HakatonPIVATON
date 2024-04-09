namespace HakatonPIVATON.Entity.Date
{
    public partial class Locality
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Point> Points { get; set; } = new List<Point>();
        public virtual ICollection<OrdersLocalities> OrderLocalities { get; set; } = new List<OrdersLocalities>();

    }
}
