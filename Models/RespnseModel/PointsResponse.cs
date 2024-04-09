namespace HakatonPIVATON.Models.RespnseModel
{
    public class PointsResponse
    {
        public long Id { get; set; }
        public UserResponse User { get; set; } = null!;
        public string LocalityName { get; set; } = null!;
        public bool IsSortCenter { get; set; }

    }
}
