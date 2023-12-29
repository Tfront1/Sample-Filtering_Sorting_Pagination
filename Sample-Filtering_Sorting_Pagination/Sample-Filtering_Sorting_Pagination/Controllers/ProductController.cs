using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample_Filtering_Sorting_Pagination.Models;
using Sample_Filtering_Sorting_Pagination.Services;

namespace Sample_Filtering_Sorting_Pagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("GetProductsByFilter")]
        public async Task<List<Product>> GetProductsByFilter()
        {
            return await productService.GetProductsByFilterAsync();
        }
    }
}
