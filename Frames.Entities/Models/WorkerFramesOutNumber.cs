namespace Frames.Entities.Models;

public class WorkerFramesOutNumber
{
    [Key]
    public int Id { get; set; }

    public int NoOfFrames { get; set; }

    public int WorkerFramesOutId { get; set; }

    public int ItemTypeId { get; set; }

    [ForeignKey("WorkerFramesOutId")]
    public WorkerFramesOut WorkerFramesOut { get; set; }

    [ForeignKey("ItemTypeId")]
    public ItemType ItemType { get; set; }
}
