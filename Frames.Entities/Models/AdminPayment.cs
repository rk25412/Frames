namespace Frames.Entities.Models;

public class AdminPayment
{
    [Key]
    public int Id { get; set; }

    [Precision(10, 2)]
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
