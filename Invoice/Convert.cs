using Invoice.Interface;

namespace Invoice.Invoice;

public class Convert : IConvert
{
    public int ConvertToInt(string number)
    {

        if (number == null || !int.TryParse(number, out int num))
        {
            return 0;
        }

        return num;
    }

    public decimal ConvertToDecimal(string number)
    {
        try
        {
            var decimalVal = System.Convert.ToDecimal(number);
            return decimalVal;
        }
        catch (OverflowException)
        {
            return 0;
        }
        catch (FormatException)
        {
            return 0;
        }
        catch (ArgumentNullException)
        {
            return 0;
        }
    }

    public string CheckToNotEmptyString(string checkString)
    {
        if (checkString == null || checkString == "")
        {
            return "";
        }

        return checkString;
    }
}
