namespace Parque.Application.Wrappers
{
    public class GenericResponse<T>
    {
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string Message { get; set; }
        public bool Succeed { get; set; }

        public GenericResponse()
        {
        }

        public GenericResponse(T data, string message = null)
        {
            Succeed = true;
            Data = data;
            Message = message;
        }

        public GenericResponse(string message)
        {
            Succeed = false;
            Message = message;
        }

    }
}
