namespace Frames.Entities.Models;

public class ItemType
{
    public ItemType()
    {
    }

    public ItemType(string itemName, decimal adminPrice, decimal workerPrice)
    {
        ItemName = itemName;
        AdminPrice = adminPrice;
        WorkerPrice = workerPrice;
    }

    [Key]
    public int Id { get; set; }

    public string ItemName { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal AdminPrice { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal WorkerPrice { get; set; }
}
