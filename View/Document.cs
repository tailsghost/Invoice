using Invoice.Abstracts;

namespace Invoice.View;

public record Document : DocumentAbstract
{
    public Document(Header header, List<Product> products, Footer footer) : base(header, products, footer)
    {

    }

    public override decimal Total => Products.Select(b => b.Sum).Sum();
}
