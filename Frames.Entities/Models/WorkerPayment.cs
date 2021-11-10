using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities.Models;

public class WorkerPayment
{
    [Key]
    public int Id { get; set; }

    public DateTime Date { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Amount { get; set; }
}
