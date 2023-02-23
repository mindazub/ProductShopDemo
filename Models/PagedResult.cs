namespace ProductShopDemo.Models
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public PagedResult(List<T> items, int totalItems, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            Items = items;
        }
    }
}
