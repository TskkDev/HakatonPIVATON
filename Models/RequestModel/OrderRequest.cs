namespace HakatonPIVATON.Models.RequestModel
{
    public class OrderRequest
    {
        public bool IsSale { get; set; }
        public decimal DeliveryRate { get; set; } = 0;
        public string Description { get; set; } = null!;
        public UserRequest User { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public PointsRequest StartPoint { get; set; } = null!;
        public PointsRequest EndPoint { get; set; } = null!;
        public List<HistrotyStatusRequest> HistrotyStatus { get; set; } = new List<HistrotyStatusRequest>();
        public List<GoodRequest> Goods { get; set; } = new List<GoodRequest>();
    }
}
