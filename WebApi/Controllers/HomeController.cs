using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.DTOs.Product;
using Models.Interfaces;
using Models.Mapping;
using WebApi.Mapping;

namespace Models.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(
            ILogger<HomeController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var allCategories = await _unitOfWork.CategoryRepository.GetAllCategories();

            if (allCategories is null)
                return NoContent();

            return Ok(allCategories.ToReadDTO());
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var allProducts = await _unitOfWork.ProductRepository.GetAllProducts();

            if(allProducts is null)
                return NoContent();

            return Ok(allProducts.ToReadDTO());
        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetProduct(id);

            if (product is null)
                return NotFound();

            return Ok(product.ToReadDto());
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductCreateDTO product)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var categories = await _unitOfWork.CategoryRepository.GetCategoriesByIds(product.Categories);

            if (categories.Count == 0)
                return BadRequest();

            await _unitOfWork.ProductRepository.AddProduct(product.ToEntity(categories));

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpGet("DeleteProduct")]
        public async Task<IActionResult> RemoveProduct(int productId)
        {
            await _unitOfWork.ProductRepository.RemoveProduct(productId);

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO product)
        {
            var categories = await _unitOfWork.CategoryRepository.GetCategoriesByIds(product.Categories);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(categories.Count == 0) 
                return BadRequest();

            await _unitOfWork.ProductRepository.UpdateProduct(product.ToEntity(categories));

            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}
