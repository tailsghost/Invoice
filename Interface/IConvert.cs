namespace Invoice.Interface
{
    public interface IConvert
    {
        string CheckToNotEmptyString(string checkString);
        decimal ConvertToDecimal(string number);
        int ConvertToInt(string number);
    }
}