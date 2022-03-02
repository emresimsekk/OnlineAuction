using AutoMapper;
using EventBusRabbitMQ.Event.Concrete;
using OnlineAuction.Sourcing.Entities;

namespace OnlineAuction.Sourcing.Mapping
{
    public class SourcingMapping : Profile
    {
        public SourcingMapping()
        {
            CreateMap<OrderCreateEvent, Bid>().ReverseMap();
        }


    }
}
