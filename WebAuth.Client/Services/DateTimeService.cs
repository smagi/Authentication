namespace WebAuth.Client.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime GetDateTimeNow()
    {
        return DateTime.Now;
    }

    public DateTime GetDateTimeNowUTC()
    {
        return DateTime.UtcNow;
    }
}
