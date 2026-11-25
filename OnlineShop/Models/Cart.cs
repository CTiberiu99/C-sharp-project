using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models;

public class Cart
{
    [Key]
    public int Id { get; set; }

    public string? SessionId { get; set; }  // User's session ID for now keep it as null until implemented

    public List<CartItem>? CartItems { get; set; } = [];
}
