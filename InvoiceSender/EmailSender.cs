namespace InvoiceSender;

public class EmailSender : IEmailSender
{
    public void SendEmail(string to, string subject, string body)
    {
        // Let's pretend this actually sends an email
        Console.WriteLine($"Sending email to {to} with subject '{subject}' and body:\n{body}");
    }
}