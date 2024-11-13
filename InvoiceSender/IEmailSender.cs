namespace InvoiceSender;

public interface IEmailSender
{
    void SendEmail(string to, string subject, string body);
}