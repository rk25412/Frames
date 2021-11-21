namespace Frames.Entities.Models;

public class AdminFramesIn
{
    public AdminFramesIn()
    {
    }

    public AdminFramesIn(int noOfFrames, DateTime date)
    {
        NoOfFrames = noOfFrames;
        Date = date;
    }


    [Key]
    public int Id { get; set; }
    public int NoOfFrames { get; set; }

    public DateTime Date { get; set; }
}
