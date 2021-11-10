using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Frames.Entities.Models;

public class WorkerFramesOut
{
    [Key]
    public int Id { get; set; }

    public DateTime Datetime { get; set; }

    public int WorkerId { get; set; }

    [System.ComponentModel.DataAnnotations.Schema.ForeignKey("WorkerId")]
    public Worker Worker { get; set; }

    public ICollection<WorkerFramesOutNumber> WorkerFramesOutNumbers { get; set; }
}
