namespace PaginationTagHelper.Pagination
{
    public interface IQueryObject
    {
        string SearchType { get; set; }
        string SearchItem { get; set; }
        string SortType { get; set; }
        bool IsSortDescending { get; set; }
    }
}
