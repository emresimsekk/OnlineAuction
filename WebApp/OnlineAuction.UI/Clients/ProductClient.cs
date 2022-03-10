using Newtonsoft.Json;
using OnlineAuction.Core.Common;
using OnlineAuction.Core.ResultModels;
using OnlineAuction.UI.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineAuction.UI.Clients
{
    public class ProductClient
    {
        public HttpClient _client { get; }

        public ProductClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(CommonInfo.LocalProductBaseAddress);
        }
        public async Task<Result<IList<ProductViewModel>>> GetProducts()
        {
            var response = await _client.GetAsync("/api/v1/Product");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ProductViewModel>>(responseData);
                if (result.Any())
                {
                    return new Result<IList<ProductViewModel>>(true,ResultConstant.RecordFound,result.ToList());
                }

                return new Result<IList<ProductViewModel>>(false, ResultConstant.RecordNotFound);
            }
            return new Result<IList<ProductViewModel>>(false, ResultConstant.RecordNotFound);
        }

    }
}
