using Parque.Application.Interfaces;

namespace Parque.Shared.DatetimeService
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
