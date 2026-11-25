using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class CartItem
    {
        [Required]
        public required Product Product { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}