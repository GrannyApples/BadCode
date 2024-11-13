// This is NOT how you should be coding!

namespace InvoiceSender;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var db = new Database();
        var emailSender = new EmailSender();
        
        var helper = new InvoiceHelper(db, emailSender);
        
        var email = "john@example.com";
        var invoicesSent = helper.Run(email);
        Console.WriteLine($"Sent {invoicesSent} invoices to {email}");
    }
}

public class InvoiceHelper
{
    private readonly IDatabase _db;
    private readonly IEmailSender _emailSender;
       
    public InvoiceHelper(IDatabase db, IEmailSender emailSender)
    {
        _db = db;
        _emailSender = emailSender;

    }

    public List<string> Run(string email)
    {
        var messages = new List<string>();
        var user = _db.GetUser(email);
        var invoice = _db.GetInvoice(user.Id);
        if (invoice == null)
        {
            return messages;
        }
        var dueDate = invoice.DueDate;
        var daysToDueDate = (dueDate.Date - DateTime.Now.Date).Days;
        
        var message = GetInvoice(user.Name, invoice.Amount, daysToDueDate);
        SendInvoice(message, user.Email);
        messages.Add(message);
        return messages;
    }
    private string GetInvoice(string name, decimal amount, int daysToDueDate)
    {
        return $"Dear {name},\n\nYour invoice of {amount} is " +
                      $"due in {daysToDueDate} days.\n\nBest regards,\nThe Invoice Team";
    }
        
    private void SendInvoice(string message, string email)
    {
        _emailSender.SendEmail(email, "Invoice Reminder", message);
    }

    internal string TestGetInvoice(string name, decimal amount, int daysToDueDate)
    {
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
        {
            throw new InvalidOperationException("This method should not be called in production");
        }

        return GetInvoice(name, amount, daysToDueDate);
    }
}