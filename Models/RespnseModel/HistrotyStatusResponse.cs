using HakatonPIVATON.Data.Entities;

namespace HakatonPIVATON.Models.RespnseModel
{
    public class HistrotyStatusResponse
    {
        public long Id { get; set; }
        public StatusResponse Status { get; set; } = null!;
        public PointsResponse Points { get; set; } = null!;
        public string SubStatus { get; set; } = null!;
    }
}
