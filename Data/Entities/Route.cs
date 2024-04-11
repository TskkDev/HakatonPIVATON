using System.ComponentModel.DataAnnotations.Schema;

namespace HakatonPIVATON.Entity.Date
{
    public partial class Route
    {
        public long Id { get; set; }
        public long FirstPointId { get; set; }
        public virtual Point FirstPoint { get; set; } = null!;
        public long SecondPointId { get; set; }
        public virtual Point SecondPoint { get; set; } = null!;
        public decimal Distance { get; set; }
        public decimal Price { get; set; }
    }
}
