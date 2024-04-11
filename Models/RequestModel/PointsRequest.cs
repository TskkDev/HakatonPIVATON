namespace HakatonPIVATON.Models.RequestModel
{
    public class PointsRequest
    {
        public long UserId { get; set; }
        public string LocalityName { get; set; } = null!;
        public bool IsSortCenter { get; set; }

    }
}
