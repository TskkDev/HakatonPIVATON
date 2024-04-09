using System.ComponentModel.DataAnnotations.Schema;

namespace HakatonPIVATON.Entity.Date
{
    public partial class Route
    {
        public long Id { get; set; }
        public long FirstPointId { get; set; }
        public long SecondPointId { get; set; }
        public decimal Distance { get; set; }

    }
}
