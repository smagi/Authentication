using WebAuth.Client.Models;

namespace WebAuth.Client.Services;

public class MessageAlertService : IMessageAlertService
{
    private const string _defaultId = "default-alert";
    public event Action<Alert> OnAlert;
    public void Alert(Alert alert)
    {
        alert.Id = alert.Id ?? _defaultId;
        OnAlert?.Invoke(alert);
    }
    public void Clear(string? id = _defaultId)
    {
        OnAlert?.Invoke(new Alert { Id = id! });
    }
    public void Error(string message, bool keepAfterRouteChange = false, bool autoClose = true)
    {
        Alert(new Alert
        {
            Type =AlertType.Error,
            Message = message,
            AutoClose = autoClose,
            KeepAfterRouteChange = keepAfterRouteChange
        });
    }
    public void Info(string message, bool keepAfterRouteChange = false, bool autoClose = true)
    {
        Alert(new Alert
        {
            Type =AlertType.Info,
            Message = message,
            AutoClose = autoClose,
            KeepAfterRouteChange = keepAfterRouteChange
        });
    }
    public void Success(string message, bool keepAfterRouteChange = false, bool autoClose = true)
    {
        Alert(new Alert
        {
            Type =AlertType.Success,
            Message = message,
            AutoClose = autoClose,
            KeepAfterRouteChange = keepAfterRouteChange
        });
    }
    public void Warn(string message, bool keepAfterRouteChange = false, bool autoClose = true)
    {
        Alert(new Alert
        {
            Type =AlertType.Warning,
            Message = message,
            AutoClose = autoClose,
            KeepAfterRouteChange = keepAfterRouteChange
        });
    }
}