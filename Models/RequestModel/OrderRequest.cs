namespace HakatonPIVATON.Models.RequestModel
{
    public class OrderRequest
    {
        public bool IsSale { get; set; }
        public decimal DeliveryRate { get; set; } = 0;
        public string Description { get; set; } = null!;
        public long UserId { get; set; }
        public DateTime? EndDate { get; set; }
        public long StartPointId { get; set; }
        public long EndPointId { get; set; }
        public List<OrderGoodsRequest> Goods { get; set; } = new List<OrderGoodsRequest>();
    }

    public class OrderGoodsRequest
    {
        public long GoodId { get; set; }
        public long Count { get; set; }
    }
}
