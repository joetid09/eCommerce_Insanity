namespace eCommerce_Insanity.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using eCommerce_Insanity.Data;
    using eCommerce_Insanity.DTOs;
    using eCommerce_Insanity.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ECommerceDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductsController(
            ILogger<ProductsController> logger,
            ECommerceDbContext dbContext,
            IMapper mapper
        )
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO productDTO)
        {
            var product = await _dbContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _mapper.Map(productDTO, product);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                //placeholder for future concurrency work i.e. edited since getting the product above
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
