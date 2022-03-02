using MediatR;
using OnlineAuctionApplication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAuctionApplication.Queries
{
    public class GetOrdersBySellerUsernameQuery:IRequest<IEnumerable<OrderResponse>>
    {
        public string Username { get; set; }

        public GetOrdersBySellerUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
