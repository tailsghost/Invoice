using Invoice.Interface;
using Invoice.View;

namespace Invoice.Invoice;

public class Start : IStart
{

    ICreateHandler _createHandler = new CreateHandler();
    IDisplayView _view = new DisplayView();

    public void Run()
    {
        Console.WriteLine("Добро пожаловать в редактор накладной!");

        var header = _createHandler.CreateHeader();

        var product = _createHandler.CreateProduct();

        var footer = _createHandler.CreateFooter();

        var document = new Document(header, product, footer);

        _view.Display(document);
    }
}
