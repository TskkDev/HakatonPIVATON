using HakatonPIVATON.Data.Entities;

namespace HakatonPIVATON.Models.RespnseModel
{
    public class OrderResponse
    {
        public long Id { get; set; }
        public bool IsSale { get; set; }
        public decimal DeliveryRate { get; set; } = 0;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long StartPointId { get; set; }
        public long EndPointId { get; set; }
        public PointsResponse? StartPoint { get; set; }
        public PointsResponse? EndPoint { get; set; }
        public string? LastStatus { get; set; }
        public List<HistrotyStatusResponse> HistrotyStatus { get; set; } = new List<HistrotyStatusResponse>();
        public List<GoodResponse> Goods { get; set; } = new List<GoodResponse>();
    }
}
