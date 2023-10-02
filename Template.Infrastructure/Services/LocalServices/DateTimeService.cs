using Template.Application.Services.Local_Services;

namespace Template.Infrastructure.Services.Local_Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
    }
}
