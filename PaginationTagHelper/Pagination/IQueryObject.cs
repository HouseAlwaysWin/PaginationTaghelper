namespace PaginationTagHelper.Pagination
{
    public interface IQueryObject
    {
        string SearchBy { get; set; }
        string SearchItem { get; set; }
        string SortBy { get; set; }
        bool IsSortDescending { get; set; }
    }
}
