namespace Parque.Application.Wrappers
{
    public class GeniricResponse<T>
    {
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string Message { get; set; }
        public bool Succeed { get; set; }

        public GeniricResponse()
        {
        }

        public GeniricResponse(T data, string message = null)
        {
            Succeed = true;
            Data = data;
            Message = message;
        }

        public GeniricResponse(string message)
        {
            Succeed = true;
            Message = message;
        }

    }
}
