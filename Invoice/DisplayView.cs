using Invoice.Interface;
using Invoice.View;

namespace Invoice.Invoice;

public class DisplayView : IDisplayView
{
    public void Display(Document document)
    {
        Console.Clear();

        Console.WriteLine($"Время создания накладной: {document.Header.date}\n" +
           $"Номер накладной: {document.Header.number}\n" +
           $"Кому: {document.Header.to}\n" +
           $"От кого {document.Header.from}\n");

        foreach (var product in document.Products.OrderBy(x => x.Id))
        {
            Console.WriteLine(
                $"П/П" + $"\t{product.Id}"
                + $"\tНаименование товара"
                + $"\t{product.Name}"
                + $"\tКол-во"
                + $"\t{product.Quantity}"
                + $"\tЦена"
                + $"\t{product.Price}"
                + $"\tСумма"
                + $"\t{product.Sum}\n"
                );
        }

        Console.WriteLine($"Общая сумма:" + $"\t{document.Total}");

        Console.WriteLine(
            $"Сдал накладную"
            + $"\t{document.Footer.passed}\n"
            + $"Принял накладную"
            + $"\t{document.Footer.accepted}"
            );
    }
}
