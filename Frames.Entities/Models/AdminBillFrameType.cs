namespace Frames.Entities.Models;

public class AdminBillFrameType
{
    [Key]
    public int Id { get; set; }

    public string FrameName { get; set; }

    [Precision(10, 2)]
    public decimal FrameRate { get; set; }

    public int AdminBillId { get; set; }

    [ForeignKey("AdminBillId")]
    public AdminBill AdminBill { get; set; }
}
