using System;
using System.ComponentModel.DataAnnotations;

namespace Frames.Entities.Models
{
    public class AdminFramesIn
    {
        [Key]
        public int Id { get; set; }
        public int NoOfFrames { get; set; }
        public DateOnly Date { get; set; }
    }
}
