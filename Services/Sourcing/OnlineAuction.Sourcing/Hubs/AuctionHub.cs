using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuction.Sourcing.Hubs
{
    public class AuctionHub:Hub
    {
        public async Task AddToGroupAsync(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId,groupName);
        }
        public async Task SendBidAsync(string groupName, string user, string bid)
        {
            await Clients.Group(groupName).SendAsync("Bids", user, bid);
        }
    }
}
