﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HakatonPIVATON.Entity.Date
{
    public partial class Order
    {
        public long Id { get; set; }
        public bool IsSale { get; set; }
        public decimal DeliveryRate { get; set; } = 0;
        public string Description { get; set; } = null!;
        public long UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long StartPointID { get; set; }
        public virtual Point StartPoint { get; set; } = null!;
        public long EndPointID { get; set; }
        public virtual Point EndPoint { get; set; } = null!;
        public ICollection<HistoryStatuses> HistoryStatuses { get; set; } = new List<HistoryStatuses>();
        public ICollection<OdersGoods> OdersGoods { get; set; } = new List<OdersGoods>();

    }
}
