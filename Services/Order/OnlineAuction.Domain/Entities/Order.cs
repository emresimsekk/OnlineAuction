﻿using OnlineAuction.Domain.Entities.Base;
using System;

namespace OnlineAuction.Domain.Entities
{
    public class Order : Entity
    {
        public string AuctionId { get; set; }
        public string SellerUserName { get; set; }
        public string ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
