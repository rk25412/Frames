namespace Frames.Entities.Models;

public class Worker
{
    public Worker()
    {
    }

    public Worker(string name)
    {
        Name = name;
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    
    public ICollection<WorkerFramesIn> WorkerFramesIn { get; set; }
    public ICollection<WorkerBill> WorkerBills { get; set; }
    public ICollection<WorkerFramesOut> WorkerFramesOut { get; set; }
}
