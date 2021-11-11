namespace Frames.Entities.Models;

public class WorkerBillFrameTypes
{
    [Key]
    public int Id { get; set; }

    public string FrameName { get; set; }

    [Precision(10, 2)]
    public decimal FrameRate { get; set; }

    public int WorkerBillId { get; set; }

    [ForeignKey("WorkerBillId")]
    public WorkerBill WorkerBill { get; set; }
}
