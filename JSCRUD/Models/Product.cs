using System.ComponentModel.DataAnnotations;

namespace JSCRUD.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    public required string Name { get; set; }

    [DataType(DataType.Currency)]
    public double Price { get; set; }
}
