using System;
using ToyShop.Shared.Models;
using Xunit;

namespace ToyShop.Shared.Tests.Models;

public class CategoryTests
{
    [Fact]
    public void Create_WithEmptyName_Throws()
    {
        Assert.Throws<ArgumentException>(() => new Category(""));
    }

    [Fact]
    public void Create_WithValidName_TrimsAndSets()
    {
        var c = new Category("   Toys   ");
        Assert.Equal("Toys", c.Name);
    }
}
