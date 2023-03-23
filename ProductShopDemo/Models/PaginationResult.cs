using System.Drawing.Printing;

namespace ProductShopDemo.Models
{
    public class PaginationResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public PaginationResult(IEnumerable<T> items, int totalPages, int currentPage, int itemsPerPage)
        {
            Items = items;
            TotalPages = totalPages;
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
        }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => (PageIndex * PageSize) < TotalPages;
    }

}
