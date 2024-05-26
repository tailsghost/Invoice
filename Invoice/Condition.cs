using Invoice.Interface;
using Invoice.View;
using System.ComponentModel;

namespace Invoice.Invoice;

public class Condition : ICondition
{

    private List<Product> products { get; set; } = new();

    public T ConditionType<T>(string text, List<Product>? products = null)
    {

        if (products != null)
            this.products = products;
        if (products == null)
            this.products = new();

        Console.WriteLine(text);

        T check = ConvertType<T>(Console.ReadLine());

        bool CheckAddHandler = false;

        while (!CheckAddHandler) {
            
            CheckAddHandler = AddHandler<T>(check, text);

            if (CheckAddHandler)
                break;

            check = ConvertType<T>(Console.ReadLine());
        }

        return check;
    }

    private bool AddHandler<T>(T check, string text)
    {

        if (check is int checkInt && checkInt <= 0)
        {
            Console.WriteLine("Значение не может быть меньше или равно 0, а так же должно быть целочисленное!");
            Console.WriteLine(text);

            return false;
        }

        if (check is decimal checkDecimal && checkDecimal <= 0)
        {
            Console.WriteLine("Значение не может быть меньше или равно 0");
            Console.WriteLine(text);

            return false;
        }

        if (check is int checkCount && products.Count > 0)
        {
            foreach (Product product in products)
            {
                if (product.Id == checkCount)
                {
                    Console.WriteLine("Номер элемента совпадает с тем, который был указан ранее!");
                    Console.WriteLine(text);
                    return false;
                }
                   
            }
        }

        if (check is string checkString && checkString == "")
        {
            Console.WriteLine("Значение не может быть пустым");
            Console.WriteLine(text);
            return false;
        }


        return true;
    }

   private static T ConvertType<T>(string input)
    {
        T result = default(T);
        var converter = TypeDescriptor.GetConverter(typeof(T));
        if (converter != null)
        {
            try
            {
                result = (T)converter.ConvertFromString(input);
            }
            catch
            {
            }
        }
        return result;
    }
}