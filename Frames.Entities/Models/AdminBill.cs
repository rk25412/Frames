using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities.Models
{
    public class AdminBill
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 12)]
        public int Month { get; set; }

        [Range(2020, 2025)]
        public int Year { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal LastMonthBill { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal LastMonthLeft { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<AdminBillFrameType> AdminBillFrameTypes { get; set; }
    }
}
