using Sample_Filtering_Sorting_Pagination.Filters;
using Sample_Filtering_Sorting_Pagination.Models;

namespace Sample_Filtering_Sorting_Pagination.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsByFilterAsync(ProductFilter filter);
    }
}
