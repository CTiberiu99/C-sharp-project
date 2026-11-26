using OnlineShop.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Tests.Models;

public class CartItemValidationTests
{
    [Fact]
    public void CartItem_WithValidProductAndQuantity_ShouldPass()
    {
        var cartItem = new CartItem
        {
            Product = new Product(),
            Quantity = 1
        };

        Assert.Empty(ValidateModel(cartItem));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void CartItem_WithNonPositiveQuantity_ShouldFail(int quantity)
    {
        var cartItem = new CartItem
        {
            Product = new Product(),
            Quantity = quantity
        };

        Assert.Contains(ValidateModel(cartItem), result =>
            result.MemberNames.Contains(nameof(CartItem.Quantity)));
    }

    private static List<ValidationResult> ValidateModel(CartItem cartItem)
    {
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(
            cartItem,
            new ValidationContext(cartItem),
            results,
            validateAllProperties: true);
        return results;
    }
}