using Invoice.View;

namespace Invoice.Abstracts;

public abstract record DocumentAbstract
{
    public Header Header { get; init; }

    public List<Product> Products { get; init; }

    public abstract decimal Total { get; }

    public Footer Footer { get; }

    protected DocumentAbstract(Header header, List<Product> products, Footer footer)
    {
        Header = header;
        Products = products;
        Footer = footer;
    }

}
