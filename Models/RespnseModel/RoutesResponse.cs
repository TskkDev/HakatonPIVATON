namespace HakatonPIVATON.Models.RespnseModel
{
    public class RoutesResponse
    {
        public long Id { get; set; }
        public PointsResponse FirstPoint { get; set; } = null!;
        public PointsResponse SecondPoint { get; set; } = null!;
        public decimal Distance { get; set; }
    }
}
