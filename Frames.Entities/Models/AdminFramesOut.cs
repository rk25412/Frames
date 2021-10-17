using System;
using System.ComponentModel.DataAnnotations;

namespace Frames.Entities.Models
{
    public class AdminFramesOut
    {
        [Key]
        public int Id { get; set; }

        public DateOnly Date { get; set; }
    }
}
