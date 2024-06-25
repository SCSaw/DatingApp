namespace API.Helpers
{
    public class PaginationParams
    {
        //set max page size that user can request
        //Dont be too big for page size, else it defeat the purpose of pagination
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; }
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}