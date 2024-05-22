namespace Invoice.Abstracts;

public abstract record ProductAbstract
{
    public int Id { get; init; }

    public string Name { get; init; }

    public int Quantity { get; init; }

    public decimal Price { get; init; }

    public abstract decimal Sum { get; }

    protected ProductAbstract(int id, string name, int quantity, decimal price)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}
