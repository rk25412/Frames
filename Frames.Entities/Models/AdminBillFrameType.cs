using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities.Models;

public class AdminBillFrameType
{
    [Key]
    public int Id { get; set; }

    public string FrameName { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal FrameRate { get; set; }

    public int AdminBillId { get; set; }

    [ForeignKey("AdminBillId")]
    public AdminBill AdminBill { get; set; }
}
