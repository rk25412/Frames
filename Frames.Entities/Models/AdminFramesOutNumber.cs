namespace Frames.Entities.Models;

public class AdminFramesOutNumber
{
    [Key]
    public int Id { get; set; }

    public int NoOfFrames { get; set; }

    public int ItemTypeId { get; set; }

    public int AdminFramesOutId { get; set; }

    [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ItemTypeId")]
    public ItemType ItemType { get; set; }

    [System.ComponentModel.DataAnnotations.Schema.ForeignKey("AdminFramesOutId")]
    public AdminFramesOut AdminFramesOut { get; set; }
}
