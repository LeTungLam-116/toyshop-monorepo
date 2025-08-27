namespace ToyShop.Shared.Models;

public class Category
{
    public int Id { get; private set; }      // để trống cho EF sau này
    public string Name { get; }

    public Category(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required", nameof(name));

        Name = name.Trim();
    }
}
