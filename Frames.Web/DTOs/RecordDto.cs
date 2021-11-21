using System.ComponentModel.DataAnnotations;

namespace Frames.Web.DTOs;

public record class DatatableDto(string Draw, int RecordsTotal, int RecordsFiltered, dynamic Data);

public record class CreateWorkerDto([Required] int Id, [Required] string Name);


public record class AdminFramesInSubDto(int Id, string Time, int NoOfFrames);
public class AdminFramesInResponseDto
{
    public AdminFramesInResponseDto(string date)
    {
        Date = date;
    }
    public string Date { get; set; }
    public int Total { get; set; } = 0;
    public List<AdminFramesInSubDto> TimeAndNo { get; set; } = new();
}
