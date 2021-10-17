using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities.Models
{
    public class ItemType
    {
        [Key]
        public int Id { get; set; }

        public string ItemName { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal AdminPrice { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal WorkerPrice { get; set; }
    }
}
