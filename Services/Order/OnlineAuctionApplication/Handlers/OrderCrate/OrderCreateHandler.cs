using AutoMapper;
using MediatR;
using OnlineAuction.Domain.Entities;
using OnlineAuction.Domain.Repositories.Base;
using OnlineAuctionApplication.Commands.OrderCreate;
using OnlineAuctionApplication.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineAuctionApplication.Handlers.OrderCrate
{
    public class OrderCreateHandler : IRequestHandler<OrderCreateCommand, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderCreateHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderResponse> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);

            if (orderEntity == null)
                throw new ApplicationException("Entity could not be mapped");

            var order = await _orderRepository.AddAsync(orderEntity);

            var orderResponse = _mapper.Map<OrderResponse>(orderEntity);

            return orderResponse;
        }
    }
}
