namespace Frames.Entities.Models;

public class WorkerFramesOut
{
    [Key]
    public int Id { get; set; }

    public DateTime Datetime { get; set; }

    public int WorkerId { get; set; }

    [ForeignKey("WorkerId")]
    public Worker Worker { get; set; }

    public ICollection<WorkerFramesOutNumber> WorkerFramesOutNumbers { get; set; }
}
