namespace HakatonPIVATON.Models.RequestModel
{
    public class HistrotyStatusRequest
    {
        public StatusRequest Status { get; set; } = null!;
        public PointsRequest Points { get; set; } = null!;
        public string SubStatus { get; set; } = null!;
    }
}
