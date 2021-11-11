namespace Frames.Entities.Models;

public class AdminPayment
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
