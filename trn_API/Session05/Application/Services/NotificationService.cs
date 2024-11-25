using Session05.Application.Interfaces;


// Implementation
namespace Session05.Application.Services;

public class EmailService : INotificationService
{
    public void Notify(string to, string subject, string body)
    {
        Console.WriteLine($"Email sent to {to} with subject {subject}");
    }
}

public class SmsService : INotificationService
{
    public void Notify(string to, string subject, string body)
    {
        Console.WriteLine($"SMS sent to {to} with subject {subject}");
    }
}