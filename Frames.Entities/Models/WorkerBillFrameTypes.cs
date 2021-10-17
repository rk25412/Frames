﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities.Models
{
    public class WorkerBillFrameTypes
    {
        [Key]
        public int Id { get; set; }

        public string FrameName { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal FrameRate { get; set; }

        public int WorkerBillId { get; set; }

        [ForeignKey("WorkerBillId")]
        public WorkerBill WorkerBill { get; set; }
    }
}
