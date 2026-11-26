using OnlineShop.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Tests.Models;

public class CartValidationTests
{
    [Fact]
    public void Cart_WithDefaultValues_ShouldPassValidationAndInitializeItems()
    {
        var cart = new Cart();
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            cart,
            new ValidationContext(cart),
            results,
            validateAllProperties: true);

        Assert.True(isValid);
        Assert.Empty(results);
        Assert.NotNull(cart.CartItems);
        Assert.Empty(cart.CartItems);
    }
}