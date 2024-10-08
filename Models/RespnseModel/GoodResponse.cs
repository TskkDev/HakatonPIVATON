﻿namespace HakatonPIVATON.Models.RespnseModel
{
    public class GoodResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Pic { get; set; } = null!;
        public decimal Price { get; set; }
        public double Weigh { get; set; }
        public string Description { get; set; } = null!;
        public long Remainder { get; set; }
        public long UserId { get; set; }
    }
}
