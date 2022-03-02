using AutoMapper;
using MediatR;
using OnlineAuction.Domain.Repositories.Base;
using OnlineAuctionApplication.Queries;
using OnlineAuctionApplication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineAuctionApplication.Handlers
{
    public class GetOrdersBySellerUsernameHandler : IRequestHandler<GetOrdersBySellerUsernameQuery, IEnumerable<OrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersBySellerUsernameHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderResponse>> Handle(GetOrdersBySellerUsernameQuery request, CancellationToken cancellationToken)
        {

            var orderList = await _orderRepository.GetOrdersBySellerUserName(request.Username);

            var newOrderList = _mapper.Map<IEnumerable<OrderResponse>>(orderList);

            return newOrderList;
        }
    }
}
