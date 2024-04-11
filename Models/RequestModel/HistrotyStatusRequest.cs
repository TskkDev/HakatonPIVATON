namespace HakatonPIVATON.Models.RequestModel
{
    public class HistrotyStatusRequest
    {
        public long StatusId { get; set; }
        public long PointsId { get; set; }
        public string SubStatus { get; set; } = null!;
    }
}
