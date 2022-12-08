using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CS.Models;

[Table("SanPham")]
public class Product
{
    [Key]
    public int Id { get; set; }

    [MaxLength(256)]
    public string Name { get; set; }

    public int Price { get; set; }
    public int Quantity { get; set; }

    [MaxLength(256)]
    public string Slug { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
}
