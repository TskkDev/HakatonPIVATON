﻿
using HakatonPIVATON.Data.Entities;
using HakatonPIVATON.Models.RequestModel;

namespace HakatonPIVATON.Entity.Date
{
    public class HistoryStatuses
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public long PointId { get; set; }
        public Point Point { get; set; } = null!;
        public long StatusId { get; set; }
        public Status Status { get; set; } = null!;
        public string SubStatus { get; set; } = null!;

    }
}
