using System.ComponentModel.DataAnnotations.Schema;

namespace HakatonPIVATON.Entity.Date
{
    public partial class Route
    {
        public int Id { get; set; }
        public int FirstPointId { get; set; }
        [NotMapped]
        public virtual Point FirstPoint { get; set; } = null!;
        public int SecondPointId { get; set; }
        [NotMapped]
        public virtual Point SecondPoint { get; set; } = null!;
        public decimal Distance { get; set; }

    }
}
