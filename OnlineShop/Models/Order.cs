using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models;
public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Customer name must be between 2 and 100 characters.")]
    public string CustomerName { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string CustomerEmail { get; set; }

    [Required]
    [Range(0.00, double.MaxValue, ErrorMessage = "Total must be a positive value.")]
    public decimal Total { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public List<OrderItem> Items { get; set; } = [];
}

