using HakatonPIVATON.Entity.Date;

namespace HakatonPIVATON.Data.Entities
{
    public class Status
    {
        public Status() { }
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<OrdersLocalities> OrdersLocalities { get; set; } = new List<OrdersLocalities>();

    }
}
