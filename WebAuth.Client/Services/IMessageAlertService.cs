using WebAuth.Client.Models;

namespace WebAuth.Client.Services;

public interface IMessageAlertService
{
    void Success(string message, bool keepAfterRouteChange = false, bool autoClose = true);
    void Error(string message, bool keepAfterRouteChange = false, bool autoClose = true);
    void Warn(string message, bool keepAfterRouteChange = false, bool autoClose = true);
    void Info(string message, bool keepAfterRouteChange = false, bool autoClose = true);
    void Alert(Alert alert);
    void Clear(string? id = null);
    event Action<Alert> OnAlert;
}