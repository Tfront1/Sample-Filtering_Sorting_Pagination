using Sample_Filtering_Sorting_Pagination.Filters;
using Sample_Filtering_Sorting_Pagination.Models;
using System.Linq;
using System.Linq.Expressions;

namespace Sample_Filtering_Sorting_Pagination.Repositories
{
    public class ProductRepository : IProductRepository
    {
        
        public async Task<List<Product>> GetProductsByFilterAsync(ProductFilter filter)
        {
            IQueryable<Product> products = GenerateProducts().AsQueryable();

            products = Filter(products, filter);

            products = Sort(products, filter);

            products = products
                .Skip(filter.From)
                .Take(filter.Size);

            return products.ToList();
        }

        private IQueryable<Product> Filter(IQueryable<Product> products, ProductFilter filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.ProductName))
            {
                products = products.Where(p =>
                    p.Name.Contains(filter.ProductName));
            }
            if (!string.IsNullOrWhiteSpace(filter.ProductDescription))
            {
                products = products.Where(p =>
                    p.Description.Contains(filter.ProductDescription));
            }
            products = products.Where(p =>
                    p.Price > filter.MinProductPrice && p.Price < filter.MaxProductPrice);
            if (!string.IsNullOrWhiteSpace(filter.SearchString))
            {
                products = products.Where(p =>
                    p.Name.Contains(filter.SearchString) ||
                    p.Description.Contains(filter.SearchString));
            }
            return products;
        }

        private IQueryable<Product> Sort(IQueryable<Product> products, ProductFilter filter)
        {
            Expression<Func<Product, object>> keySelector = filter.SortColumn?.ToLower() switch
            {
                "name" => product => product.Name,
                "description" => product => product.Description,
                "price" => product => product.Price,
                _ => product => product.Id
            };
            if (filter.SortDirection == Filters.Common.SortFilter.SortDirections.desc)
            {
                products = products.OrderByDescending(keySelector);
            }
            else if(filter.SortDirection == Filters.Common.SortFilter.SortDirections.asc)
            {
                products = products.OrderBy(keySelector);
            }

            return products;
        }
        private ICollection<Product> GenerateProducts(){
            ICollection<Product> products = new List<Product>();
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
            for (int i = 0; i < 5; i++)
            {
                products.Add(new Product
                {
                    Id = Guid.NewGuid(),
                    Name = $"{i}Tovar",
                    Description = $"{i}Tovar",
                    Price = random.Next(100, 1001),
                });
            }
            return products;
        }
    }
}
