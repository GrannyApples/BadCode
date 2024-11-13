namespace InvoiceSender;

public partial class Invoice
{
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
}