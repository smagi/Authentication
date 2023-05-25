namespace WebAuth.Client.Services;

public interface IDateTimeService
{
    DateTime GetDateTimeNow();
    DateTime GetDateTimeNowUTC();
}
