using OnlineShop.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace OnlineShop.Tests.Models;

public class ProductValidationTests
{
    private List<ValidationResult> ValidateModel(Product product)
    {
        var context = new ValidationContext(product);
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(product, context, results, validateAllProperties: true);
        return results;
    }

    // ===== NAME VALIDATION TESTS =====

    [Fact]
    public void Product_WithValidName_ShouldPass()
    {
        // Arrange
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void Product_WithNullName_ShouldFail()
    {
        // Arrange
        var product = new Product
        {
            Name = null,
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.MemberNames.Contains("Name") &&
                                     r.ErrorMessage.Contains("required"));
    }

    [Fact]
    public void Product_WithEmptyName_ShouldFail()
    {
        // Arrange
        var product = new Product
        {
            Name = "",
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.MemberNames.Contains("Name"));
    }

    [Fact]
    public void Product_WithNameTooShort_ShouldFail()
    {
        // Arrange - name is 2 chars, minimum is 3
        var product = new Product
        {
            Name = "AB",
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.MemberNames.Contains("Name") &&
                                     r.ErrorMessage.Contains("3"));
    }

    [Fact]
    public void Product_WithNameExactlyMinLength_ShouldPass()
    {
        // Arrange - name is exactly 3 chars (minimum)
        var product = new Product
        {
            Name = "ABC",
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void Product_WithNameExactlyMaxLength_ShouldPass()
    {
        // Arrange - name is exactly 100 chars (maximum)
        var product = new Product
        {
            Name = new string('A', 100),
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void Product_WithNameExceedingMaxLength_ShouldFail()
    {
        // Arrange - name is 101 chars, maximum is 100
        var product = new Product
        {
            Name = new string('A', 101),
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.MemberNames.Contains("Name") &&
                                     r.ErrorMessage.Contains("100"));
    }

    // ===== DESCRIPTION VALIDATION TESTS =====

    [Fact]
    public void Product_WithValidDescription_ShouldPass()
    {
        // Arrange
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "A high-quality cotton t-shirt",
            Price = 29.99m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void Product_WithNullDescription_ShouldPass()
    {
        // Arrange - Description is not required
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = null,
            Price = 29.99m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void Product_WithDescriptionExceedingMaxLength_ShouldFail()
    {
        // Arrange - description is 501 chars, maximum is 500
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = new string('A', 501),
            Price = 29.99m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.MemberNames.Contains("Description"));
    }

    // ===== PRICE VALIDATION TESTS =====

    [Fact]
    public void Product_WithValidPrice_ShouldPass()
    {
        // Arrange
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void Product_WithPriceAtMinBoundary_ShouldPass()
    {
        // Arrange - price is 0.01 (minimum)
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = 0.01m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void Product_WithPriceAtMaxBoundary_ShouldPass()
    {
        // Arrange - price is 10000 (maximum)
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = 10000m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void Product_WithPriceBelowMinimum_ShouldFail()
    {
        // Arrange - price is 0, minimum is 0.01
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = 0m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.MemberNames.Contains("Price"));
    }

    [Fact]
    public void Product_WithNegativePrice_ShouldFail()
    {
        // Arrange
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = -10m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.MemberNames.Contains("Price"));
    }
    
    // ===== CATEGORY VALIDATION TESTS =====

    [Fact]
    public void Product_WithValidCategory_ShouldPass()
    {
        // Arrange
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void Product_WithNullCategory_ShouldFail()
    {
        // Arrange - Category is required
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = 29.99m,
            Category = null,
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.MemberNames.Contains("Category"));
    }

    [Fact]
    public void Product_WithEmptyCategory_ShouldFail()
    {
        // Arrange
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.MemberNames.Contains("Category"));
    }

    [Fact]
    public void Product_WithCategoryExceedingMaxLength_ShouldFail()
    {
        // Arrange - category is 51 chars, maximum is 50
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = 29.99m,
            Category = new string('A', 51),
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.MemberNames.Contains("Category"));
    }

    // ===== STOCK VALIDATION TESTS =====

    [Fact]
    public void Product_WithValidStock_ShouldPass()
    {
        // Arrange
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void Product_WithZeroStock_ShouldPass()
    {
        // Arrange - 0 is valid (out of stock but valid)
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "Shirts",
            Stock = 0,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void Product_WithMaxStock_ShouldPass()
    {
        // Arrange - stock is 10000 (maximum)
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "Shirts",
            Stock = 10000,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void Product_WithNegativeStock_ShouldFail()
    {
        // Arrange
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "Shirts",
            Stock = -1,
            ImageUrl = "tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.MemberNames.Contains("Stock") &&
                                     r.ErrorMessage.Contains("negative"));
    }

    // ===== IMAGE URL VALIDATION TESTS =====

    [Fact]
    public void Product_WithValidImageUrl_ShouldPass()
    {
        // Arrange
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "images/tshirt.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }

    // ===== BOUNDARY TESTS =====

    [Theory]
    [InlineData("ABC")]  // 3 chars (min)
    [InlineData("ValidName")]
    [InlineData("A very long product name that is exactly one hundred characters long!!!!!!!!!!!!!")]  // 100 chars
    public void Product_WithVariousValidNames_ShouldPass(string name)
    {
        // Arrange
        var product = new Product
        {
            Name = name,
            Description = "Cotton blend",
            Price = 29.99m,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "image.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }

    [Theory]
    [InlineData(0.01)]
    [InlineData(99.99)]
    [InlineData(500)]
    [InlineData(10000)]
    public void Product_WithVariousValidPrices_ShouldPass(decimal price)
    {
        // Arrange
        var product = new Product
        {
            Name = "Classic T-Shirt",
            Description = "Cotton blend",
            Price = price,
            Category = "Shirts",
            Stock = 50,
            ImageUrl = "image.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }

    // ===== COMPLETE VALID PRODUCT TEST =====

    [Fact]
    public void Product_WithCompleteValidData_ShouldPass()
    {
        // Arrange - a complete, valid product
        var product = new Product
        {
            Name = "Premium Running Shoes",
            Description = "High-performance running shoes with advanced cushioning technology",
            Price = 149.99m,
            Category = "Shoes",
            Stock = 45,
            ImageUrl = "running-shoes.jpg"
        };

        // Act
        var results = ValidateModel(product);

        // Assert
        Assert.Empty(results);
    }
}
