using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models;

public class OrderItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }

    [Required]
    public Product Product { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
    public int Quantity { get; set; }

    [Required]
    [Range(0.00, double.MaxValue, ErrorMessage = "Unit price must be a positive value.")]
    public decimal UnitPrice { get; set; }
}
