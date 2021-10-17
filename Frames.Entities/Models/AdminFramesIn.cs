using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities.Models
{
    public class AdminFramesIn
    {
        [Key]
        public int Id { get; set; }
        public int NoOfFrames { get; set; }

        public DateTime Date { get; set; }
    }
}
