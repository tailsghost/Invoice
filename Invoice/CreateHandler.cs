using Invoice.Interface;
using Invoice.View;

namespace Invoice.Invoice;

public class CreateHandler : ICreateHandler
{

    ICondition _condition = new Condition();

    public Header CreateHeader()
    {

        var number = _condition.ConditionAtInt("Введите номер накладной!");

        var get = _condition.ConditionAtString("Введите для кого накладная");

        var send = _condition.ConditionAtString("Введите от кого накладная");

        var header = new Header(DateTime.Now, number, get, send);

        return header;

    }

    public Footer CreateFooter()
    {
        var passed = _condition.ConditionAtString("Введите кто сдал накладную");

        var accepted = _condition.ConditionAtString("Введите окто принял накладную");

        var footer = new Footer(passed, accepted);

        return footer;

    }

    public List<Product> CreateProduct()
    {

        List<Product> products = new List<Product>();

        bool check = false;

        while (!check)
        {
            var id = _condition.ConditionAtInt("Введите номер товара");

            var name = _condition.ConditionAtString("Введите наименование товара");

            var quantity = _condition.ConditionAtInt("Введите кол-во товара");

            var price = _condition.ConditionAtDecimal("Введите цену товара (Дробь через запятую)");

            products.Add(new Product(id, name, quantity, price));

            check = CheckInput();
        }

        return products;

    }

    private bool CheckInput()
    {

        Console.WriteLine("Добавить еще продукт? Введите Y/N");
        var check = Console.ReadKey();
        Console.WriteLine("\n");
        if (check.Key == ConsoleKey.Y)
        {
            return false;
        }


        if (check.Key == ConsoleKey.N)
        {
            return true;
        }

        CheckInput();

        return false;
    }
}
