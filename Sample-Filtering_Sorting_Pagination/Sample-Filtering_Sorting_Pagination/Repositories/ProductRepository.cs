using Sample_Filtering_Sorting_Pagination.Models;

namespace Sample_Filtering_Sorting_Pagination.Repositories
{
    public class ProductRepository : IProductRepository
    {
        
        public async Task<List<Product>> GetProductsByFilterAsync()
        {
            IEnumerable<Product> products = GenerateProducts();
            return products.ToList();
        }

        private List<Product> GenerateProducts(){
            List<Product> products = new List<Product>();
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                products.Add(new Product
                {
                    Id = Guid.NewGuid(),
                    Name = $"{i}Product",
                    Description = $"{i}ProductDescription",
                    Price = random.Next(10, 101),
                });
            }
            return products;
        }
    }
}
