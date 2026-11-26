using OnlineShop.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Tests.Models;

public class OrderValidationTests
{
    [Fact]
    public void Order_WithValidData_ShouldPass()
    {
        Assert.Empty(ValidateModel(new Order
        {
            CustomerName = "Alex Smith",
            CustomerEmail = "alex@example.com",
            Total = 49.99m
        }));
    }

    [Fact]
    public void Order_WithInvalidEmail_ShouldFail()
    {
        var results = ValidateModel(new Order
        {
            CustomerName = "Alex Smith",
            CustomerEmail = "not-an-email",
            Total = 49.99m
        });

        Assert.Contains(results, result =>
            result.MemberNames.Contains(nameof(Order.CustomerEmail)));
    }

    [Fact]
    public void Order_WithNegativeTotal_ShouldFail()
    {
        var results = ValidateModel(new Order
        {
            CustomerName = "Alex Smith",
            CustomerEmail = "alex@example.com",
            Total = -1m
        });

        Assert.Contains(results, result =>
            result.MemberNames.Contains(nameof(Order.Total)));
    }

    private static List<ValidationResult> ValidateModel(Order order)
    {
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(
            order,
            new ValidationContext(order),
            results,
            validateAllProperties: true);
        return results;
    }
}