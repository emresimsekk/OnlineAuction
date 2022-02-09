using Microsoft.AspNetCore.Mvc;
using OnlineAuction.Sourcing.Entities;
using OnlineAuction.Sourcing.Repository.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace OnlineAuction.Sourcing.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        #region Variables
        private readonly IBidRepository _bidRepository;

        #endregion

        #region Constructor
        public BidController(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }

        #endregion

        #region Crud_Actions

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> SendBid([FromBody] Bid bid)
        {
            await _bidRepository.SendBid(bid);
            return Ok();
        }

        [HttpGet("GetBidsByAuctionId")]
        [ProducesResponseType(typeof(IEnumerable<Bid>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Bid>>> GetBidsByAuctionId(string id)
        {
            IEnumerable<Bid> bids = await _bidRepository.GetBidsByAuctionId(id);
            return Ok(bids);
        }

        [HttpGet("GetWinnerBid")]
        [ProducesResponseType(typeof(Bid), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Bid>> GetWinnerBid(string id)
        {
            Bid bid = await _bidRepository.GetWinnerBid(id);
            return Ok(bid);
        }
        #endregion
    }
}
