using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities.Models;

public class AdminFramesOut
{
    [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }
}
