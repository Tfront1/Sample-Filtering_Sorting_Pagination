using Sample_Filtering_Sorting_Pagination.Filters;
using Sample_Filtering_Sorting_Pagination.Models;
using Sample_Filtering_Sorting_Pagination.Repositories;

namespace Sample_Filtering_Sorting_Pagination.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<Product>> GetProductsByFilterAsync(ProductFilter filter) 
        {
            return await productRepository.GetProductsByFilterAsync(filter);
        }
    }
}
