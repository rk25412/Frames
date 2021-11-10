using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Frames.Entities.Models;

public class Worker
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<WorkerFramesIn> WorkerFramesIn { get; set; }
    public ICollection<WorkerBill> WorkerBills { get; set; }
    public ICollection<WorkerFramesOut> WorkerFramesOut { get; set; }
}
