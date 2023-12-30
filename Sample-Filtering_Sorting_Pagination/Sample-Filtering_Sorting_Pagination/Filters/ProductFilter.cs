using Sample_Filtering_Sorting_Pagination.Filters.Common;

namespace Sample_Filtering_Sorting_Pagination.Filters
{
    public class ProductFilter : SearchStringFilter
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int MinProductPrice { get; set; }
        public int MaxProductPrice { get; set; } = int.MaxValue;
    }
}
