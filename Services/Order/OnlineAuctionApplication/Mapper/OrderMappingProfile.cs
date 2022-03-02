using AutoMapper;
using OnlineAuction.Domain.Entities;
using OnlineAuctionApplication.Commands.OrderCreate;
using OnlineAuctionApplication.Responses;

namespace OnlineAuctionApplication.Mapper
{
    public class OrderMappingProfile:Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderCreateCommand>().ReverseMap();
            CreateMap<Order, OrderResponse>().ReverseMap();
        }
    }
}
