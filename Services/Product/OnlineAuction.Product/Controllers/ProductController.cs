using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineAuction.Product.Repositories.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace OnlineAuction.Product.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Variables

        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;

        #endregion

        #region Constructor

        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        #endregion

        #region Crud_Actions

        [HttpGet]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.OK)] // Dönüş Tipi
        public async Task<ActionResult<IEnumerable<Entities.Product>>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Product>> GetProduct(string id)
        {
            var product = await _productRepository.GetProduct(id);

            if (product == default || product == null)
            {
                _logger.LogError($"Product with id : {id}, hasn't been found in database");
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Product>> CreateProduct([FromBody] Entities.Product product)
        {
            await _productRepository.Create(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Product>> UpdateProduct([FromBody] Entities.Product product)
        {
            await _productRepository.Update(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Product>> DeleteProductById(string id)
        {
            return Ok(await _productRepository.Delete(id));
        }
        #endregion

    }
}
