namespace Invoice.Interface
{
    public interface ICondition
    {
        decimal ConditionAtDecimal(string text);
        int ConditionAtInt(string text);
        string ConditionAtString(string text);
    }
}