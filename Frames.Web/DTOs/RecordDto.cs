using System.ComponentModel.DataAnnotations;

namespace Frames.Web.DTOs;

public record class DatatableDto(string Draw, int RecordsTotal, int RecordsFiltered, dynamic Data);


public record class CreateWorkerDto([Required] int Id, [Required] string Name);
