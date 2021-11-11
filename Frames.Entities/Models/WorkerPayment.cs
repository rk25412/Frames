namespace Frames.Entities.Models;

public class WorkerPayment
{
    [Key]
    public int Id { get; set; }

    public DateTime Date { get; set; }

    [Precision(10, 2)]
    public decimal Amount { get; set; }
}
