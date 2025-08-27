namespace ToyShop.Shared.Models;

public class Product
{
    public int Id { get; private set; }        // EF sẽ set sau này
    public string Name { get; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public DateTime CreatedAt { get; }

    public Product(string name, decimal price, int stock = 0)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required", nameof(name));
        if (price < 0)
            throw new ArgumentOutOfRangeException(nameof(price), "Price must be >= 0");
        if (stock < 0)
            throw new ArgumentOutOfRangeException(nameof(stock), "Stock must be >= 0");

        Name = name.Trim();
        Price = price;
        Stock = stock;
        CreatedAt = DateTime.UtcNow;   // dùng UTC cho nhất quán
    }

    public void ChangePrice(decimal newPrice)
    {
        if (newPrice < 0) throw new ArgumentOutOfRangeException(nameof(newPrice));
        Price = newPrice;
    }

    public void AddStock(int qty)
    {
        if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
        Stock += qty;
    }

    public void RemoveStock(int qty)
    {
        if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
        if (qty > Stock) throw new InvalidOperationException("Not enough stock");
        Stock -= qty;
    }
}
