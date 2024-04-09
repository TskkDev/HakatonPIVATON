using System.ComponentModel.DataAnnotations.Schema;

namespace HakatonPIVATON.Entity.Date
{
    public partial class Point
    {
        public Point()
        {
            Order = new HashSet<Order>();
            Route = new HashSet<Route>();
        }
        public long Id { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public long LocalityId { get; set; }
        public virtual Locality Locality { get; set; } = null!;
        public bool IsSortCenter { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Route> Route { get; set; }

    }
}
