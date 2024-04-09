
using HakatonPIVATON.Data.Entities;

namespace HakatonPIVATON.Entity.Date
{
    public class OrdersLocalities
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public long LocalityId { get; set; }
        public Locality Locality { get; set; } = null!;
        public long StatusId { get; set; }
        public StatusResponse Status { get; set; } = null!;
        public string SubStatus { get; set; } = null!;

    }
}
