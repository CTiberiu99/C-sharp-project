using OnlineShop.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Tests.Models;

public class OrderItemValidationTests
{
    [Fact]
    public void OrderItem_WithValidData_ShouldPass()
    {
        Assert.Empty(ValidateModel(new OrderItem
        {
            Product = new Product(),
            Quantity = 1,
            UnitPrice = 19.99m
        }));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void OrderItem_WithNonPositiveQuantity_ShouldFail(int quantity)
    {
        var results = ValidateModel(new OrderItem
        {
            Product = new Product(),
            Quantity = quantity,
            UnitPrice = 19.99m
        });

        Assert.Contains(results, result =>
            result.MemberNames.Contains(nameof(OrderItem.Quantity)));
    }

    [Fact]
    public void OrderItem_WithNegativeUnitPrice_ShouldFail()
    {
        var results = ValidateModel(new OrderItem
        {
            Product = new Product(),
            Quantity = 1,
            UnitPrice = -1m
        });

        Assert.Contains(results, result =>
            result.MemberNames.Contains(nameof(OrderItem.UnitPrice)));
    }

    private static List<ValidationResult> ValidateModel(OrderItem orderItem)
    {
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(
            orderItem,
            new ValidationContext(orderItem),
            results,
            validateAllProperties: true);
        return results;
    }
}