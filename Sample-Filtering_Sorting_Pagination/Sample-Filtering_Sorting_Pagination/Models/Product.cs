namespace Sample_Filtering_Sorting_Pagination.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int Price { get; set; }
    }
}
