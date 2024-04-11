using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HakatonPIVATON.Entity.Date
{
    public partial class Point
    { 
        public long Id { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public long LocalityId { get; set; }
        public virtual Locality Locality { get; set; } = null!;
        public bool IsSortCenter { get; set; }
        public virtual ICollection<Order> StartPoint { get; set; } = null!;
        public virtual ICollection<Order> EndPoint { get; set; } = null!;
        public virtual ICollection<Route> FirstPoint { get; set; } = null!;
        public virtual ICollection<Route> SecondPoint { get; set; } = null!;
        public virtual ICollection<HistoryStatuses> HistoryStatuses { get; set; } = new List<HistoryStatuses>();


    }
}
