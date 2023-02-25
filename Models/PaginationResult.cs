namespace ProductShopDemo.Models
{
    public class PaginationResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }

        public PaginationResult(IEnumerable<T> items, int totalPages, int currentPage, int itemsPerPage)
        {
            Items = items;
            TotalPages = totalPages;
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
        }
    }

}
