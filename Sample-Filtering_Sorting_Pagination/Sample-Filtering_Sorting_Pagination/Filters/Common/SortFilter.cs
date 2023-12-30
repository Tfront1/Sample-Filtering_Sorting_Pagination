namespace Sample_Filtering_Sorting_Pagination.Filters.Common
{
    public class SortFilter : OffsetFilter
    {
        public enum SortDirections {
            asc = 1,
            desc = 2
        };
        public SortDirections SortDirection { get; set; }
        public string SortColumn { get; set; } = string.Empty;
    }
}
