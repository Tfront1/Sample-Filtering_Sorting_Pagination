using System.ComponentModel.DataAnnotations;

namespace Sample_Filtering_Sorting_Pagination.Filters.Common
{
    public class OffsetFilter : SizeFilter
    {
        [Range(0, int.MaxValue, ErrorMessage = "Field value should be in a range from 0 to 2 147 483 647")]
        public int From { get; set; } = 0;
    }
}
