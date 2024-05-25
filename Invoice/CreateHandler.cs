using Invoice.Interface;
using Invoice.View;

namespace Invoice.Invoice;

public class CreateHandler : ICreateHandler
{

    ICondition _condition = new Condition();

    private List<Product> _products {  get; set; } = new List<Product>();

    public Header CreateHeader()
    {

        var number = _condition.ConditionType<int>("Введите номер накладной!");

        var to = _condition.ConditionType<string>("Введите для кого накладная");

        var from = _condition.ConditionType<string>("Введите от кого накладная");

        var header = new Header(DateTime.Now, number, to, from);

        return header;

    }

    public Footer CreateFooter()
    {
        var passed = _condition.ConditionType<string>("Введите кто сдал накладную");

        var accepted = _condition.ConditionType<string>("Введите кто принял накладную");

        var footer = new Footer(passed, accepted);

        return footer;

    }

    public List<Product> CreateProduct()
    {

        bool check = false;

        while (!check)
        {
            var id = _condition.ConditionType<int>("Введите номер товара", _products);

            var name = _condition.ConditionType<string>("Введите наименование товара");

            var quantity = _condition.ConditionType<int>("Введите кол-во товара");

            var price = _condition.ConditionType<decimal>("Введите цену товара (Дробь через запятую)");

            check = CheckInput();

            _products.Add(new Product(id, name, quantity, price));
        }

        return _products;

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
