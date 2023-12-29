using Sample_Filtering_Sorting_Pagination.Models;

namespace Sample_Filtering_Sorting_Pagination.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsByFilterAsync();
    }
}
