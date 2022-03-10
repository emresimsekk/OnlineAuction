using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineAuction.Core.Repositories;
using OnlineAuction.Core.ResultModels;
using OnlineAuction.UI.Clients;
using OnlineAuction.UI.ViewsModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineAuction.UI.Controllers
{ 
    public class AuctionController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ProductClient _productClient;
        private readonly SourcingClient _sourcingClient;
        private readonly BidClient _bidClient;

        public AuctionController(IUserRepository userRepository, ProductClient productClient, SourcingClient sourcingClient, BidClient bidClient)
        {
            _userRepository = userRepository;
            _productClient = productClient;
            _sourcingClient = sourcingClient;
            _bidClient = bidClient;
        }

        public async Task<IActionResult> Index()
        {
            var auctionList = await _sourcingClient.GetAuctions();
            if (auctionList.IsSuccess)
                return View(auctionList.Data);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //TODO:Product GetAll

            var productList =await _productClient.GetProducts();
            if (productList.IsSuccess)
            {
                ViewBag.ProductList = productList.Data;
            }
      

            var userList = await _userRepository.GetAllAsync();
            ViewBag.UserList = userList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuctionViewModel auctionViewModel)
        {
            auctionViewModel.Status = 1;
            auctionViewModel.CreatedAt = DateTime.Now;
            var createAuction = await _sourcingClient.CreateAuction(auctionViewModel);
            if (createAuction.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(auctionViewModel);
        }

        public async Task<IActionResult> Detail(string id)
        {
            AuctionBidsViewModel model = new AuctionBidsViewModel();
            var auctionResponse = await _sourcingClient.GetAuctionsById(id);
            var bidResponse = await _bidClient.GetAllBidsByAuctionId(id);

            model.SellerUserName = HttpContext.User?.Identity.Name;
            model.AuctionId = auctionResponse.Data.Id;
            model.ProductId = auctionResponse.Data.ProductId;
            model.Bids = bidResponse.Data;
            var isAdmin = HttpContext.Session.GetString("IsAdmin");
            model.IsAdmin = Convert.ToBoolean(isAdmin);
            return View(model);
        }

        [HttpPost]
        public async Task<Result<string>> SendBid(BidViewModel model)
        {
            model.CreateAt = DateTime.Now;
            var sendBidResponse = await _bidClient.SendBid(model);
            return sendBidResponse;
        }

        [HttpPost]
        public async Task<Result<string>> CompleteBid(string id)
        {
            
            var completeBidResponse = await _sourcingClient.CompleteBid(id);
            return completeBidResponse;
        }
    }
}
