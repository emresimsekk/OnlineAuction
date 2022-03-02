using EventBusRabbitMQ.Event.Interfaces;
using System;

namespace EventBusRabbitMQ.Event.Concrete
{
    public class OrderCreateEvent : IEvent
    {
        public string Id { get; set; }
        public string AuctionId { get; set; }
        public string ProductId { get; set; }
        public string SellerUsername { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Quantity { get; set; }
    }
}
