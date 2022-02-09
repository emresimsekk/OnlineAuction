using DnsClient.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineAuction.Sourcing.Entities;
using OnlineAuction.Sourcing.Repository.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace OnlineAuction.Sourcing.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        #region Variables
        private readonly IAuctionRepository _auctionRepository;
        private readonly ILogger<AuctionController> _logger;
        #endregion

        #region Constructor
        public AuctionController(IAuctionRepository auctionRepository, ILogger<AuctionController> logger)
        {
            _auctionRepository = auctionRepository;
            _logger = logger;
        }
        #endregion

        #region Crud_Actions
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Auction>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Auction>>> GetAuctions()
        {
            return Ok(await _auctionRepository.GetAuctions());
        }


        [HttpGet("{id:length(24)}", Name = "GetAuction")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Auction), (int)HttpStatusCode.OK)]
       
        public async Task<ActionResult<Auction>> GetAuction(string id)
        {
            var auction = await _auctionRepository.GetAuction(id);
            if (auction == null)
            {
                _logger.LogError($"Auction with id :{id} hasn't been found in database.");
                return NotFound();
            }


            return Ok(auction);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Auction), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<Auction>> CreateAuction([FromBody] Auction auction)
        {
            await _auctionRepository.Create(auction);
            return CreatedAtRoute("GetAuction", new { id = auction.Id }, auction);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Auction), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<Auction>> UpdateAuction([FromBody] Auction auction)
        {
            await _auctionRepository.Update(auction);
           return CreatedAtRoute(nameof(GetAuction), new { id = auction.Id }, auction);
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Auction), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<Auction>> DeleteAuction(string id)
        {
            return Ok(await _auctionRepository.Delete(id));
        }

        #endregion
    }
}
