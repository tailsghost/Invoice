using Invoice.Abstracts;

namespace Invoice.View;

public record Product : ProductAbstract
{
    public Product(int id, string name, int quantity, decimal price) : base(id, name, quantity, price)
    {
    }

    public override decimal Sum => Price * Quantity;
}
