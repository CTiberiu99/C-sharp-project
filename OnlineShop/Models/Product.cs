using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 100 characters.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? Description { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
    public decimal Price { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Category must be between 3 and 50 characters.")]
    public string Category { get; set; }  // e.g., "Shirts", "Pants", "Shoes"

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative value.")]
    public int Stock { get; set; }

    //[Url(ErrorMessage = "Image URL must be a valid URL.")]
    public string? ImageUrl { get; set; }  // filename like "product1.jpg"
}

