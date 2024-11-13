namespace InvoiceSender;

public class Database : IDatabase
{
    // Let's pretend this actually connects to a database
    public User GetUser(string email) => new User { Id = 1, Name = "John Doe", Email = email };
    public Invoice? GetInvoice(int userId) => new Invoice { UserId = userId, Amount = 100, DueDate = DateTime.Now.AddDays(7) };
}