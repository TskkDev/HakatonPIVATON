
namespace HakatonPIVATON.Entity.Date
{
    public class OrdersLocalities
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int LocalityId { get; set; }
        public Locality Locality { get; set; } = null!;


    }
}
