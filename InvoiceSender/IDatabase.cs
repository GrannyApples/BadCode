namespace InvoiceSender;

public interface IDatabase
{
    User GetUser(string email);
    Invoice? GetInvoice(int userId);
}