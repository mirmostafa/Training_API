namespace Session05.Application.Interfaces;

// Interface definition
public interface INotificationService
{
    void Notify(string to, string subject, string body);
}
