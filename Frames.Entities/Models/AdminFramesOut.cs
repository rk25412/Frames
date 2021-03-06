namespace Frames.Entities.Models;

public class AdminFramesOut
{
    [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public ICollection<AdminFramesOutNumber> AdminFramesOutNumbers { get; set; }
}
