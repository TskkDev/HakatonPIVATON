using System.ComponentModel.DataAnnotations.Schema;

namespace HakatonPIVATON.Entity.Date
{
    public partial class Order
    {
        public int Id { get; set; }
        public bool IsSale { get; set; }
        public decimal DeliveryRate { get; set; } = 0;
        public string Description { get; set; } = null!;
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StartPointId { get; set; }
        [NotMapped]
        public virtual Point StartPoint { get; set; } = null!;
        public int EndPointId { get; set; }
        [NotMapped]
        public virtual Point EndPoint { get; set; } = null!;
        public virtual ICollection<OrdersLocalities> OrderLocalities { get; set; } = new List<OrdersLocalities>();
        public virtual ICollection<OdersGoods> OdersGoods { get; set; } = new List<OdersGoods>();

    }
}
