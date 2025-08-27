using System;
using ToyShop.Shared.Models;
using Xunit;

namespace ToyShop.Shared.Tests.Models;

public class ProductTests
{
    [Fact]
    public void Create_WithValidData_SetsProperties()
    {
        var p = new Product("Lego Car", 199_000m, stock: 5);

        Assert.Equal("Lego Car", p.Name);
        Assert.Equal(199_000m, p.Price);
        Assert.Equal(5, p.Stock);
        Assert.True((DateTime.UtcNow - p.CreatedAt).TotalSeconds < 5);
    }

    [Fact]
    public void Create_WithEmptyName_Throws()
    {
        Assert.Throws<ArgumentException>(() => new Product("  ", 10m));
    }

    [Fact]
    public void ChangePrice_WithNegative_Throws()
    {
        var p = new Product("Lego", 10m);
        Assert.Throws<ArgumentOutOfRangeException>(() => p.ChangePrice(-1m));
    }

    [Fact]
    public void AddStock_IncreasesStock()
    {
        var p = new Product("Lego", 10m, stock: 1);
        p.AddStock(3);
        Assert.Equal(4, p.Stock);
    }

    [Fact]
    public void RemoveStock_TooMuch_Throws()
    {
        var p = new Product("Lego", 10m, stock: 2);
        Assert.Throws<InvalidOperationException>(() => p.RemoveStock(3));
    }
}
