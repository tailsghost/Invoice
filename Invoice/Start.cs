using Invoice.Interface;
using Invoice.View;
using System.IO;

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

        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        var filePath = Path.Combine(desktopPath, "document.txt");

        using (StreamWriter writer = new StreamWriter(File.Create(filePath)))
        {
            writer.WriteLine($"[{document.Header}]");

            foreach (var doc in document.Products)
            {
                writer.WriteLine($"[{doc}]");
            }

            writer.WriteLine($"[Общая сумма: {document.Total}]");

            writer.WriteLine($"[{document.Footer}]");

        }

        _view.Display(document);
    }
}
