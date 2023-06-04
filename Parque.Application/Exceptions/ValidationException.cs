using FluentValidation.Results;

namespace Parque.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("One or more errors of validation")
        {
            Errors = new List<string>();
        }


        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var item in failures)
            {
                Errors.Add(item.ErrorMessage);
            }
        }
        public List<string> Errors { get; }
    }
}
