using Invoice.View;

namespace Invoice.Interface
{
    public interface ICreateHandler
    {
        Footer CreateFooter();
        Header CreateHeader();
        List<Product> CreateProduct();
    }
}