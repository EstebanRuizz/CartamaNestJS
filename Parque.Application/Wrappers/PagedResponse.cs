namespace Parque.Application.Wrappers
{
    public class PagedResponse<T> : GenericResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Succeed = true;
            this.Message = null;
            this.Data = data;
            this.Errors = null;
        }
    }
}
