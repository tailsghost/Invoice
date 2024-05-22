using Invoice.Interface;

namespace Invoice.Invoice;

public class Condition : ICondition
{

    IConvert _convert = new Convert();


    public int ConditionAtInt(string text)
    {
        Console.WriteLine(text);

        var check = _convert.ConvertToInt(Console.ReadLine());

        while (check == 0)
        {
            Console.WriteLine(text);
            check = _convert.ConvertToInt(Console.ReadLine());
        }

        return check;
    }

    public decimal ConditionAtDecimal(string text)
    {
        Console.WriteLine(text);

        var check = _convert.ConvertToDecimal(Console.ReadLine());

        while (check == 0)
        {
            Console.WriteLine(text);
            check = _convert.ConvertToDecimal(Console.ReadLine());
        }

        return check;
    }

    public string ConditionAtString(string text)
    {
        Console.WriteLine(text);

        var check = _convert.CheckToNotEmptyString(Console.ReadLine());

        while (check == "")
        {
            Console.WriteLine(text);
            check = _convert.CheckToNotEmptyString(Console.ReadLine());
        }

        return check;
    }
}