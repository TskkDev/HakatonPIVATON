using System.ComponentModel.DataAnnotations.Schema;

namespace HakatonPIVATON.Entity.Date
{
    public partial class Point
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public int LocalityId { get; set; }
        public virtual Locality Locality { get; set; } = null!;
        public bool IsSortCenter { get; set; }
        [NotMapped]
        public virtual ICollection<Order> Order { get; set; } = new List<Order>();
        [NotMapped]
        public virtual ICollection<Route> Route { get; set; } = new List<Route>();

    }
}
