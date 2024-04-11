namespace HakatonPIVATON.Models.RespnseModel
{
    public class RoutesResponse
    {
        public long Id { get; set; }
        public long FirstPointId { get; set; }
        public long SecondPointId { get; set; }
        public decimal Distance { get; set; }
        public decimal Price { get; set; }
    }
}
