namespace HakatonPIVATON.Models.RespnseModel
{
    public class PointsResponse
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long LocalityId { get; set; }
        public string LocalityName { get; set; } = null!;
        public bool IsSortCenter { get; set; }

    }
}
