namespace Parque.Application.Parameters
{
    public class RequestedParameters
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public RequestedParameters()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public RequestedParameters(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? pageSize : 10;
        }
    }
}
